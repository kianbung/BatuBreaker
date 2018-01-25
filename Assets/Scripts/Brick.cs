using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    private int timesHit;
    public Sprite[] hitSprites;
    private LevelManager levelManager;
    private bool isBreakable;
    public GameObject boom;
    public static int breakableCount;

    public AudioClip pew;

    /* Works on fixing breakableCount bug, but not ideal implementation.
     * Reason: Awake() triggers on each object spawn. If new brick spawns midgame, will reset to 0.
     * 
    private void Awake() {
        breakableCount = 0;
    }
    */

    // Use this for initialization
    void Start () {
        // call Level Manager
        levelManager = GameObject.FindObjectOfType<LevelManager>();

        isBreakable = (this.tag == "Breakable");
        timesHit = 0;
        if (isBreakable) {
            breakableCount++;
            //Debug.Log("Spawned bricks: " + breakableCount);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
        

	}

    void OnCollisionExit2D(Collision2D collision) {
        
        if (isBreakable) {
            HandleHits();
        }
    }

    void HandleHits() {
        this.timesHit++;
        //Debug.Log("Hit Item: " + gameObject.GetInstanceID() + " Times: " + timesHit);

        int maxHit = hitSprites.Length + 1;

        if (timesHit >= maxHit) {
            BreakBrick();
            // SimulateWin();
        } else {
            DamageBrick();

        }
    }

    /* Testing jer - delete when done
    void SimulateWin() {
        levelManager.NextLevel();

    }
    */

    void DamageBrick() {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError("Missing Sprite on " + gameObject.name);
        }
        

    }

    void BreakBrick() {
        Destroy(gameObject);
        Boom();
        breakableCount--;
        // Debug.Log("Bricks left: " + breakableCount);
        AudioSource.PlayClipAtPoint(pew , this.transform.position);
        levelManager.WinCheck();
    }


    // Smoke Particle effect
    void Boom() {
        //Debug.Log("Boom triggered");

        // Set colour of smoke to same as brick (set colour first, else clone come out wrong colour)
        ParticleSystem.MainModule main = boom.GetComponent<ParticleSystem>().main;
        main.startColor = gameObject.GetComponent<SpriteRenderer>().color;

        // Instantiate (Clone) from public GameObject set in Inspector
        GameObject exp = Instantiate(boom, this.transform.position, Quaternion.identity);
        // Play Boomz
        exp.GetComponent<ParticleSystem>().Play();
        Destroy(exp, 1);
    }
}
