using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    public int health = 1;

    public GameObject laserPrefab;
    public float projectileSpeed = 0;
    public float fireRate = 0.5f;

    private float fireInterval = 0; 
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Projectile missile = other.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
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

    void Update()
    {
        if (fireInterval > .99f)
        {
            Fire();
        }
        else
        {
            fireInterval += fireRate;
        }
    }
}
