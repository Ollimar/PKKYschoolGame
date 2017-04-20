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

    // Use these variables only if the button is the last number of transition phase
    public bool transition = false;
    public int transitions = 0;
    public int transitionsRequired = 4;

    public Image ringImage;

    public GameObject successEffect;
    public GameObject failEffect;

    public Canvas myCanvas;

    private ScriptMinigameTest scriptMiniGameTest;

    private AudioSource myAudio;
    public AudioClip scoreSound;
    public AudioClip failSound;

	void Start () 
    {
        scriptMiniGameTest = Camera.main.GetComponent<ScriptMinigameTest>();
        ringImage.enabled = false;
        myCanvas = GameObject.Find( "Canvas" ).GetComponent<Canvas>();
        myAudio = Camera.main.GetComponent<AudioSource>();
	}
	
	void Update () {

        timer += Time.deltaTime;

        if(timer <= 0f) 
        {
            ringImage.transform.localScale = new Vector3( 1f, 1f, 1f );
        }

        if(timer >= activateTime) 
        {
            shrink = true;
        }

        if(shrink) 
        {
            ringImage.enabled = true;
            ringImage.transform.localScale -= new Vector3(1f,1f,1f)*shrinkSpeed*Time.deltaTime;
        }

        if(ringImage.transform.localScale.x <= 0f) 
        {
            Inactivate();
        }
	}

    public void Spawn() 
    {
        timer = 0f;
        ringImage.transform.localScale = new Vector3( shrinkSpeed, shrinkSpeed, shrinkSpeed );
    }

    public void Score() 
    {
        if(!transition) 
        {
            if(scriptMiniGameTest.tapCount == number) 
            {
                scriptMiniGameTest.tapCount += 1;
                scriptMiniGameTest.score += 100;
                scriptMiniGameTest.scoreText.text = "SCORE: " + scriptMiniGameTest.score.ToString();
                scriptMiniGameTest.bar.fillAmount = scriptMiniGameTest.bar.fillAmount + 0.05f;
                GameObject win;
                myAudio.PlayOneShot(scoreSound);
                win = Instantiate( successEffect, transform.position, transform.rotation );
                win.transform.parent = myCanvas.transform;
                ringImage.transform.localScale = new Vector3( 1f, 1f, 1f );
                gameObject.SetActive( false );
            }
        }
        else 
        {
            TransitionScore();
        }
    }

    public void TransitionScore() 
    {
        if(scriptMiniGameTest.tapCount == number && transitions == transitionsRequired) 
        {
                scriptMiniGameTest.tapCount += 1;
                scriptMiniGameTest.score += 100;
                scriptMiniGameTest.scoreText.text = "SCORE: " + scriptMiniGameTest.score.ToString();
                scriptMiniGameTest.bar.fillAmount = scriptMiniGameTest.bar.fillAmount + 0.05f;
                GameObject win;
                myAudio.PlayOneShot(scoreSound);
                win = Instantiate( successEffect, transform.position, transform.rotation );
                win.transform.parent = myCanvas.transform;
                gameObject.SetActive( false );
        }
        else 
        {
            return;
        }
    }

    public void Inactivate() 
    {
        scriptMiniGameTest.tapCount += 1;
        GameObject fail;
        myAudio.PlayOneShot(failSound);
        fail = Instantiate( failEffect, transform.position, transform.rotation );
        fail.transform.parent = myCanvas.transform;
        ringImage.transform.localScale = new Vector3( 1f, 1f, 1f );
        gameObject.SetActive( false );
    }

    public void Hold() 
    {
        if(transition && transitions == transitionsRequired) 
        {
            TransitionScore();
            scriptMiniGameTest.isHolding = true;
        }
    }

    public void Release() 
    {
        scriptMiniGameTest.isHolding = false;
    }

    public void AddToTransition() 
    {
        transitions += 1;
    }
}
