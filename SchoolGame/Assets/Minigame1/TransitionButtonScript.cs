using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionButtonScript : MonoBehaviour {

    public int transitionNumber = 0;
    public GameObject goalNumber;

    private AudioSource myAudio;
    public AudioClip scoreSound;

	// Use this for initialization
	void Start () {
        myAudio = goalNumber.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Next() 
    {
        if(goalNumber.GetComponent<NumberButtonScript>().transitions == transitionNumber) 
        {
            goalNumber.GetComponent<NumberButtonScript>().AddToTransition();
            myAudio.PlayOneShot( scoreSound );
            gameObject.SetActive(false);
        }
    }
}
