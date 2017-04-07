using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomization : MonoBehaviour {

    public Image fadeScreen;

    private Animator anim;
    private Animator animFadeScreen;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        animFadeScreen = fadeScreen.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RotateRight() 
    {
        transform.Rotate( Vector3.up * 10f * Time.deltaTime );
    }

    public void Done() {
        anim.SetBool("Done",true);
    }

    public void FadeScreen() {
        animFadeScreen.SetBool("Done",true);
    }

    public void NextLevel() {
        Application.LoadLevel("TestLevel");
    }
}
