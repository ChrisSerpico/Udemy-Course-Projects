using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 0.5f;
    public float padding = 0.5f; // padding between player and edge of screen 

    float xmin;
    float xmax;

	
	void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
    }
    
    // Update is called once per frame
	void Update () 
    {
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
}
