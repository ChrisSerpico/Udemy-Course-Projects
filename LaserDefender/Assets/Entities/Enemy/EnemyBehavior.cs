using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    public int health = 1;
    public int score = 150;

    public GameObject laserPrefab;
    public float projectileSpeed = 0;
    public float fireRate = 2f;

    private ScoreKeeper scoreKeeper;

    public AudioClip fireSound;
    public AudioClip deathSound; 

    void OnTriggerEnter2D(Collider2D other)
    {
        Projectile missile = other.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
                Die();
            }
            Debug.Log("Enemy hit by laser!"); 
        } 
    }

    void Die()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        scoreKeeper.Score(score);
        Destroy(gameObject);
    }

    // fire a projectile
    void Fire()
    {
        GameObject laser = (GameObject)Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    void Start()
    {
        InvokeRepeating("Fire", fireRate, fireRate);
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }
}
