using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 0.5f;
    public float padding = 0.5f; // padding between player and edge of screen 

    public GameObject laserPrefab;
    public float projectileSpeed = 0;
    public float fireRate = 0.2f;
    public float health = 4;

    float xmin;
    float xmax;

    public AudioClip fireSound; 

	
	void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
    }
    
    // fire a projectile
    void Fire()
    {
        GameObject laser = (GameObject)Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    // Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, fireRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        
        // restrict player to gamespace
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

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
            Debug.Log("Player hit by laser!");
        }
    }
}
