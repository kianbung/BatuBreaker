using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private bool hasStarted = false;
    private AudioSource dun;

    // Why cannot Vector2??
    private Vector3 paddleBallDistance;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleBallDistance = transform.position - paddle.transform.position;
        //print ("Height diff:" + paddleBallDistance.y);

        dun = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

        // Lock ball to paddle
        if (hasStarted == false) {
            transform.position = paddle.transform.position + paddleBallDistance;

            //Debug.Log(transform.position);
            // Mouse click to launch ball
            if (Input.GetMouseButtonDown(0)) {
                //print("Mouse Clicked");
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }

        }
        
	}

    void OnCollisionExit2D(Collision2D collision) {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (hasStarted) {
            dun.Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }

        
        //Debug.Log("Random " + tweak);

    }
}
