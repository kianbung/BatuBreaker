using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
    private LevelManager levelManager;

    void Start() {
        // call Level Manager
        levelManager = GameObject.FindObjectOfType<LevelManager>();    
    }

    // Ball triggers this if slightly above paddle upon game init
    // Alt fix: Collision detection to Continuous (but uses more CPU)
    void OnTriggerEnter2D(Collider2D trigger) {
        Debug.Log(gameObject.name + " hit by" + trigger.gameObject.name);
        levelManager.LoadLevel("Lose");
    }
}
