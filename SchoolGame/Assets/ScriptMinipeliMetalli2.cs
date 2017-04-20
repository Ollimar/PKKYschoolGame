using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMinipeliMetalli2 : MonoBehaviour {

    public GameObject touchParticle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Ray ray;
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity)) 
        {
            if(hit.transform.tag == "Hitsattava") 
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
        }		
	}
}
