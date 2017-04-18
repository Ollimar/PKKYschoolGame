using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptOpeningScene : MonoBehaviour {

    public float timer = 3f;

    public Image kollektiweLogo;
    public Image pkkyLogo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void LogoChange() {
        kollektiweLogo.enabled = false;
        pkkyLogo.enabled = true;
    }

    public void NextLevel() {
        Application.LoadLevel("TitleScreen");
    }
}
