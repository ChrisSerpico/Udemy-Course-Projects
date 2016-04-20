using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    public int health = 1;
    public int score = 150;

    public GameObject laserPrefab;
    public float projectileSpeed = 0;
    public float fireRate = 2f;

    private ScoreKeeper scoreKeeper;

    void OnTriggerEnter2D(Collider2D other)
    {
        Projectile missile = other.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
                scoreKeeper.Score(score);
                Destroy(gameObject);
            }
            Debug.Log("Enemy hit by laser!"); 
        } 
    }

    // fire a projectile
    void Fire()
    {
        GameObject laser = (GameObject)Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed);
    }

    void Start()
    {
        InvokeRepeating("Fire", 0.00001f, fireRate);
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }
}
