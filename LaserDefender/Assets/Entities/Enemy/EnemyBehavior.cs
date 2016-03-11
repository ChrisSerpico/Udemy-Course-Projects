using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    public int health = 1; 

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
}
