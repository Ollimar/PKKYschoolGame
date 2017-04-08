using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptOpeningScene : MonoBehaviour {

    public float timer = 3f;

	// Use this for initialization
	void Start () {
		StartCoroutine("Wait");
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator Wait() {
        yield return new WaitForSeconds( timer );
        Application.LoadLevel("CharacterCreation");
    }
}
