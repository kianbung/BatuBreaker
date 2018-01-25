using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    public float minX, maxX;
    private Ball ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!autoPlay) {
            MouseControl();
        } else {
            AutoPlay();
        }



    }

    void MouseControl() {
        // Remember that I deviated from Vector3 and also course solution
        // 16 is the number of blocks on screen below vv
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        // Got the below code from the Mathf.Clamp documentation page
        // Mathf.Clamp prevents paddle from going offscreen
        transform.position = new Vector2(Mathf.Clamp(mousePosInBlocks, minX, maxX), transform.position.y);

        //Vector2 paddlePos = new Vector2(mousePosInBlocks, this.transform.position.y);
        //this.transform.position = paddlePos;

        //print(mousePosInBlocks);
    }

    void AutoPlay() {

        transform.position = new Vector2(Mathf.Clamp(ball.transform.position.x, 0.5f, 15.5f), transform.position.y);

    }
}
