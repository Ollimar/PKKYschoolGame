using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Wait());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator Wait() {
        yield return new WaitForSeconds( 2f );
        gameObject.SetActive( false );
    }
}
