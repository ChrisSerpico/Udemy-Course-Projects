using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float xVelocity = 2f;
    public float yVelocity = 10f;

    private Paddle paddle;

    private Vector3 paddleToBallVector;

    private bool hasStarted = false;
    
    // Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            // lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            // wait for a mouse press to launch 
            if (Input.GetMouseButtonDown(0))
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
                hasStarted = true;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = GetComponent<Rigidbody2D>().velocity;

        if (collision.collider.gameObject.tag == "Paddle")
        {
            tweak.x = xVelocity * ((this.transform.position.x - paddle.transform.position.x) / (paddle.GetComponent<Collider2D>().bounds.size.x / 2)) * 2f;
            tweak.y = yVelocity;
            Debug.Log(tweak);
        }

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity = tweak;
        }
    }
}
