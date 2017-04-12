using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour {

    public Image fadeScreen;

    public float rotAmount = 0;
    public float dif = 0.5f;
    public int rotDirection = 1;

    private Animator anim;
    private Animator animFadeScreen;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        animFadeScreen = fadeScreen.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate( Vector3.up * rotAmount*Time.deltaTime);

       if(Input.GetMouseButtonDown(0)) 
        {
            dif = 0f;
        }
        
        else if(Input.GetMouseButton(0)) 
        {
            dif = Mathf.Abs( rotAmount - Input.GetAxis( "Mouse X" ) );
            
            if(rotAmount < Input.GetAxis("Mouse X"))
            {
                rotDirection = -1;
                transform.Rotate(Vector3.up, -dif);
            }

            if(rotAmount > Input.GetAxis("Mouse X")) 
            {
                rotDirection = 1;
                transform.Rotate( Vector3.up, dif );
            }

            rotAmount = -Input.GetAxis("Mouse X");
        }
       else {


            transform.Rotate( Vector3.up, dif * rotDirection );
        }

        if(Input.GetMouseButtonUp(0)) 
        {
            dif = 0f;
        }

	}

    public void Done() {
        anim.SetBool("Done",true);
    }

    public void FadeScreen() {
        animFadeScreen.SetBool("Done",true);
    }

    public void NextLevel() {
        Application.LoadLevel("WorldMap");
    }
}
