using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    // how much the ball is affected by hitting different parts of the paddle
    public float ballRedirectFactor;
    
    float mousePosInBlocks;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, this.transform.position.z);
        
        mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);

        this.transform.position = paddlePos;
	}
}
