using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMetalliala : MonoBehaviour {

    public Transform text;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            text.GetComponent<Animator>().SetBool( "AtDoor", true );
        }
    }

        void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            text.GetComponent<Animator>().SetBool( "AtDoor", false );
        }
    }

}
