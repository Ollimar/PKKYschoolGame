using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptMinipeliMetalli2 : MonoBehaviour {

    public GameObject touchParticle;
    public GameObject hitsausJalki;

    public Transform target;
    public Transform parent;

    public Canvas pauseMenu;
    public Animator pauseMenuAnim;

    public bool paused = false;

    public Text gameCounter;
    public float startTimer;

    // Use this for initialization
    void Start() 
    {
       pauseMenu = GameObject.Find( "PauseCanvas" ).GetComponent<Canvas>();
       pauseMenu.enabled = false;
       pauseMenuAnim = GameObject.Find( "MetallialaImage" ).GetComponent<Animator>();
       target = GameObject.Find( "Target" ).transform;
       gameCounter = GameObject.Find( "Text" ).GetComponent<Text>();
       startTimer = 0f;
       parent = GameObject.FindGameObjectWithTag( "parent" ).transform;
    }

    // Update is called once per frame
    void Update() 
    {
  
        startTimer += Time.deltaTime;

        if(startTimer > 1f && startTimer < 2f) 
        {
            gameCounter.GetComponent<Text>().text = "3";
        }

        if(startTimer > 2f && startTimer < 3f) 
        {
            gameCounter.GetComponent<Text>().text = "2";
        }

        if(startTimer > 3f && startTimer < 4f) 
        {
            gameCounter.GetComponent<Text>().text = "1";
        }

        if(startTimer > 4f && startTimer < 5f) 
        {
            gameCounter.GetComponent<Text>().text = "Start!";
        }

        if(startTimer > 5f && startTimer < 6f) 
        {
            gameCounter.GetComponent<Text>().enabled = false;
            target.GetComponent<Target>().go = true;
        }


        Ray ray;
        RaycastHit hit;

        if(Input.touchCount>0) 
        {

        ray = Camera.main.ScreenPointToRay( Input.GetTouch(0).position );

        if ( Physics.Raycast( ray, out hit, Mathf.Infinity ) ) 
        {
            
        if ( hit.transform.tag == "Hitsattava" ) 
            {
                if ( Input.touchCount > 0 ) 
                {
                    touchParticle.SetActive( true );
                    touchParticle.transform.position = hit.point;
                    GameObject jalki = hitsausJalki;
                    Instantiate( jalki, new Vector3( hit.point.x, hit.point.y, -0.5f ), transform.rotation );
                    jalki.transform.parent = parent.transform;
                } 

            }

            if ( hit.transform.tag == "HitsausJalki" ) 
                {
                    if ( Input.touchCount > 0 ) 
                    {
                        print( "hitsaan" );
                        if(hit.transform.localScale.x < 1f) {
                            hit.transform.localScale += new Vector3( 0.1f, 0.1f, 0.1f )*Time.deltaTime;
                        } 
                    }
                }
            }
        }
        else 
        {
            touchParticle.SetActive( false );
        }
    }

    public void Pause() 
    {
        if(!paused) {
            pauseMenu.enabled = true;
            paused = true;
            pauseMenuAnim.SetBool("Touched", true);
            //Time.timeScale = 0f;
        }
        else {
            pauseMenu.enabled = false;
            paused = false;
            pauseMenuAnim.SetBool("Touched", false);
            //Time.timeScale = 1f;
        }
        
    }

    public void Menu() 
    {
        Application.LoadLevel("Metalliala");
    }
}