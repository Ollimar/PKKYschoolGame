using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour {

    public float speed = 1f;
    public Transform myTarget;
    public GameObject[] points;
    public int currentPoint = 0;

    public bool go = false;

    public Text gameCounter;
    public GameObject okButton;

    private ScriptMinipeliMetalli2 minipeliMetalli2;

	// Use this for initialization
	void Start () 
    {
        points = GameObject.FindGameObjectsWithTag("HitsausPoint");
        myTarget.position = new Vector3(points[1].transform.position.x,points[1].transform.position.y,points[1].transform.position.z);
        minipeliMetalli2 = GameObject.Find( "Main Camera" ).GetComponent<ScriptMinipeliMetalli2>();
        okButton = GameObject.Find( "OKButton" );
        okButton.SetActive(false);
        //minipeliMetalli2.gameCounter.GetComponent<Text>().enabled = false;
        minipeliMetalli2.startTimer = 0f;
        gameCounter = GameObject.Find( "Text" ).GetComponent<Text>();
        gameCounter.GetComponent<Text>().enabled = true;
        go = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(go) 
        {
            transform.position = Vector3.MoveTowards( transform.position, myTarget.position, speed*Time.deltaTime );
        }

        if(transform.position == points[currentPoint].transform.position) 
        {
                if(points[currentPoint].GetComponent<HitsausPoint>().enpoint == true) 
                {
                    go = false;
                    myTarget = null;
                    minipeliMetalli2.gameCounter.GetComponent<Text>().enabled = true;
                    minipeliMetalli2.gameCounter.GetComponent<Text>().text = "Finish!";
                    okButton.SetActive(true);
                }
                
                else 
                {   
                    currentPoint += 1;
                    myTarget.position = points[currentPoint].transform.position;
                }

        }
	}
}
