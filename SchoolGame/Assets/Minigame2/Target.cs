using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public float speed = 1f;
    public Transform myTarget;
    public Transform[] points;

    public bool go = false;

	// Use this for initialization
	void Start () 
    {
        myTarget = points[1];
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(go) 
        {
            transform.position = Vector3.MoveTowards( transform.position, myTarget.position, speed*Time.deltaTime );
        }

        if(transform.position == points[1].position) 
        {
            print("point1");
            myTarget.position = points[2].position;
        }
	}
}
