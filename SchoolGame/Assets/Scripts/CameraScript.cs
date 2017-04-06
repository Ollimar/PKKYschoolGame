using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform target;
    public Transform camTargetY;

    public float smoothTime = 1f;
    public float cameraOffsetX = 5f;
   // public float cameraOffsetY = 5f;
    public float cameraDepth = -10f;
    public PlayerMovement playerMovement;

    public bool xPlus = true;
    public bool xMinus = false;

	
	void Start () 
    {
        target = GameObject.Find( "Player" ).transform;
        playerMovement = GameObject.Find( "Player" ).GetComponent<PlayerMovement>();
	}
	
	
	void LateUpdate () 
    {
        Vector3 playerPos = new Vector3(target.transform.position.x, transform.position.y, cameraDepth);
        Vector3 myPos = new Vector3(transform.position.x, camTargetY.position.y, transform.position.z);

        transform.position = Vector3.Lerp( myPos, new Vector3(myPos.x,playerMovement.camTargetY.position.y,myPos.z), smoothTime * Time.deltaTime );

        if(xPlus) 
        {
            playerPos.x = target.transform.position.x + cameraOffsetX;
            transform.position = Vector3.Lerp( myPos, playerPos, smoothTime * Time.deltaTime );
        }

        if (xMinus) 
        {
            playerPos.x = target.transform.position.x - cameraOffsetX;
            transform.position = Vector3.Lerp( myPos, playerPos, smoothTime * Time.deltaTime );
        }
       
	}
}
