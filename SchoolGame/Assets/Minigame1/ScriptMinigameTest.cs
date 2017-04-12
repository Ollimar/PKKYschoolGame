using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMinigameTest : MonoBehaviour {


    public int score = 0;
    public int tapCount = 1;

    public GameObject[] numbers;
    public GameObject[] transitions;

    public GameObject touchParticle;

    public bool isHolding = false;
    public bool parsec1 = true;
    public bool parsec2 = true;
    public bool parsec3 = true;

    public float timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;
        
        Ray ray;
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity)) 
        {
            if(Input.touchCount > 0) 
            {
                touchParticle.SetActive( true );
                touchParticle.transform.position = hit.point;
            }
            else 
            {
                touchParticle.SetActive( false );
            }

        }

        if(timer >= 5f && timer < 10f && parsec1 == true) 
        {
            numbers[0].SetActive( true );
            numbers[1].SetActive( true );
            numbers[2].SetActive( true );
            parsec1 = false;
        }

        if(timer >= 10f && timer < 15f && parsec2 == true) 
        {
            numbers[3].SetActive( true );
            numbers[4].SetActive( true );
            numbers[5].SetActive( true );
            parsec2 = false;
        }

        if(timer >= 15f && timer < 20f && parsec3 == true) 
        {
            transitions[0].SetActive( true );
            numbers[6].SetActive( true );
            numbers[7].SetActive( true );
            parsec3 = false;
        }
	}
}
