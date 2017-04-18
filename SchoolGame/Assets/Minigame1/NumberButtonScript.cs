using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberButtonScript : MonoBehaviour {

    public int number = 1;

    public float timer;

    public float shrinkSpeed = 0.2f;
    public float activateTime = 0f;

    public bool shrink = false;
    public bool transition = false;

    public Image ringImage;

    public GameObject successEffect;
    public GameObject failEffect;

    public Canvas myCanvas;

    private ScriptMinigameTest scriptMiniGameTest;


	void Start () 
    {
        scriptMiniGameTest = Camera.main.GetComponent<ScriptMinigameTest>();
        ringImage.enabled = false;
        myCanvas = GameObject.Find( "Canvas" ).GetComponent<Canvas>();
	}
	
	void Update () {

        timer += Time.deltaTime;

        if(timer >= activateTime) {
            shrink = true;
        }

        if(shrink) 
        {
            ringImage.enabled = true;
            ringImage.transform.localScale -= new Vector3(1f,1f,1f)*Time.deltaTime;
        }

        if(ringImage.transform.localScale.x <= 0f) 
        {
            Inactivate();
        }
	}

    public void Spawn() {
        timer = 0f;
        ringImage.transform.localScale = new Vector3( shrinkSpeed, shrinkSpeed, shrinkSpeed );
    }

    public void Score() 
    {
        if(scriptMiniGameTest.tapCount == number) 
        {
                scriptMiniGameTest.tapCount += 1;
                scriptMiniGameTest.score += 100;
                scriptMiniGameTest.scoreText.text = "SCORE: " + scriptMiniGameTest.score.ToString();
                scriptMiniGameTest.bar.fillAmount = scriptMiniGameTest.bar.fillAmount + 0.05f;
                GameObject win;
                win = Instantiate( successEffect, transform.position, transform.rotation );
                win.transform.parent = myCanvas.transform;
                gameObject.SetActive( false );
        }
    }

    public void TransitionScore() 
    {
        if(scriptMiniGameTest.tapCount == number) 
        {
                scriptMiniGameTest.tapCount += 1;
                scriptMiniGameTest.score += 100;
                scriptMiniGameTest.scoreText.text = "SCORE: " + scriptMiniGameTest.score.ToString();
                gameObject.SetActive( false );
        }
    }

    public void Inactivate() 
    {
        scriptMiniGameTest.tapCount += 1;
        GameObject fail;
        fail = Instantiate( failEffect, transform.position, transform.rotation );
        fail.transform.parent = myCanvas.transform;
        gameObject.SetActive( false );
    }

    public void Hold() 
    {
        if(transition) 
        {
            TransitionScore();
            scriptMiniGameTest.isHolding = true;
        }
    }

    public void Release() 
    {
        scriptMiniGameTest.isHolding = false;
    }
}
