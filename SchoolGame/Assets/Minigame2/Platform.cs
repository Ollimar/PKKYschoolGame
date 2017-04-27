using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public BoxCollider2D myCol;
    public bool pass = true;

	// Use this for initialization
	void Start () {
        myCol = GetComponentInChildren<BoxCollider2D>();    
	}
	
	// Update is called once per frame
	void Update () {
        myCol.enabled = !pass;
	}

    void OnTriggerEnter2D(Collider2D other) {
        pass = true;
    }

    void OnTriggerStay2D(Collider2D other) {
        pass = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        pass = false;
    }
}
