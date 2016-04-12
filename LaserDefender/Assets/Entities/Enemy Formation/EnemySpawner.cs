using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

    public float width = 10f;
    public float height = 5f;

    public float speed = 5f;
    private bool movingRight = true;
    private float xmin, xmax;
    private float padding = -0.25f;

    public float spawnDelay = 0.5f; 
    // Use this for initialization
	void Start () 
    {
        SpawnUntilFull();

        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
	}

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    void Update()
    {
        // keep formation from moving out of playspace
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x + width / 2f > xmax)
                movingRight = false;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x - width / 2f < xmin)
                movingRight = true; 
        }

        // regenerate formation if all enemies die
        if (AllMembersDead())
        {
            SpawnUntilFull();
        }
    }

    private Transform NextFreePosition()
    {
        foreach(Transform childPosition in transform)
        {
            if (childPosition.childCount == 0)
            {
                return childPosition;
            }
        }

        return null;
    }
    
    private bool AllMembersDead()
    {
        foreach(Transform childPosition in transform)
        {
            if (childPosition.childCount > 0)
                return false;
        }

        return true;
    }

    private void SpawnEnemy(Transform cPosition)
    {
        GameObject enemy = (GameObject)Instantiate(enemyPrefab, cPosition.transform.position, Quaternion.identity);
        enemy.transform.parent = cPosition;
    }

    private void SpawnAllEnemies()
    {
        foreach (Transform child in transform)
        {
            SpawnEnemy(child);
        }
    }

    private void SpawnUntilFull()
    {
        Transform nextPosition = NextFreePosition();

        if (nextPosition)
        {
            SpawnEnemy(nextPosition);
        }

        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }
}
