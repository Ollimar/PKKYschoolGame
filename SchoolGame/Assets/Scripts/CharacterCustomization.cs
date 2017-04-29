using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour {

    public Image fadeScreen;
    public InputField nameField;

    public float rotAmount = 0;
    public float dif = 0.5f;
    public int rotDirection = 1;

    public GameObject[] hats;
    public Material bodyMaterial;
    public Material pantsMaterial;

    public Color myColor1;
    public Color myColor2;
    public Color myColor3;
    public Color myColor4;
    public Color myColor5;
    public Color myColor6;
    public Color myColor7;
    public Color myColor8;
    public Color myColor9;

    public GameObject bodyColor;
    public GameObject pantsColor;

    private Animator anim;
    private Animator animFadeScreen;

    private ScriptPlayerData playerData;

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();
        animFadeScreen = fadeScreen.GetComponent<Animator>();
        playerData = GameObject.Find( "PlayerData" ).GetComponent <ScriptPlayerData> ();
        nameField.text = null;
        bodyColor = GameObject.Find( "BodyColors" );
        bodyColor.SetActive(false);
        pantsColor = GameObject.Find( "PantsColors" );
        pantsColor.SetActive( false );
	}
	
	// Update is called once per frame
	void Update () 
    {
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


        Ray ray;
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);


        if(Input.touchCount>0) 
        {
        if ( Physics.Raycast( ray, out hit, Mathf.Infinity ) ) {
            if ( hit.transform.name == "ShirtCollider" ) 
            {
                print("Click Shirt");
                bodyColor.SetActive(true);
                pantsColor.SetActive(false);
            }

            if ( hit.transform.name == "PantsCollider" ) 
            {
                print("Click Pants");
                bodyColor.SetActive(false);
                pantsColor.SetActive(true);
            }

            if ( hit.transform.name == "BGRCollider" ) 
            {
                bodyColor.SetActive(false);
                pantsColor.SetActive(false);
            }
        }
      }

	}

    public void NextHat() {
        hats[0].SetActive(false);
        hats[1].SetActive(true);
        playerData.hatNumber = 2;
    }

    public void PrevHat() {
        hats[0].SetActive(true);
        hats[1].SetActive(false);
        playerData.hatNumber = 1;
    }

    public void Done() {

      if(nameField.text == null) 
      {
            print( "Please name your character" );
            return;
      }
      else 
      {
            playerData.playerName = nameField.text;
            anim.SetBool("Done",true);
      }  


    }

    public void ChangeShirtColor1() 
    {
       bodyMaterial.color = myColor1;      
    }

    public void ChangeShirtColor2() 
    {
        bodyMaterial.color = myColor2;
    }

    public void ChangeShirtColor3() 
    {
        bodyMaterial.color = myColor3;
    }

    public void ChangeShirtColor4() 
    {
        bodyMaterial.color = myColor4;
    }

    public void ChangeShirtColor5() 
    {
        bodyMaterial.color = myColor5;
    }

    public void ChangeShirtColor6() 
    {
        bodyMaterial.color = myColor6;
    }

    public void ChangeShirtColor7() 
    {
        bodyMaterial.color = myColor7;
    }

    public void ChangeShirtColor8() 
    {
        bodyMaterial.color = myColor8;
    }

    public void ChangeShirtColor9() 
    {
        bodyMaterial.color = myColor9;
    }

    //Define pants color
    public void ChangePantsColor1() 
    {
       pantsMaterial.color = myColor1;      
    }

    public void ChangePantsColor2() 
    {
        pantsMaterial.color = myColor2;
    }

    public void ChangePantsColor3() 
    {
        pantsMaterial.color = myColor3;
    }

    public void ChangePantsColor4() 
    {
        pantsMaterial.color = myColor4;
    }

    public void ChangePantsColor5() 
    {
        pantsMaterial.color = myColor5;
    }

    public void ChangePantsColor6() 
    {
        pantsMaterial.color = myColor6;
    }

    public void ChangePantsColor7() 
    {
        pantsMaterial.color = myColor7;
    }

    public void ChangePantsColor8() 
    {
        pantsMaterial.color = myColor8;
    }

    public void ChangePantsColor9() 
    {
        pantsMaterial.color = myColor9;
    }

    public void FadeScreen() {
        animFadeScreen.SetBool("Done",true);
    }

    public void NextLevel() {
        Application.LoadLevel("WorldMap");
    }
}
