using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptMinipeliMetalli2 : MonoBehaviour {

    public GameObject touchParticle;
    public GameObject hitsausJalki;

    public GameObject[] hitsauskohteet;
    public int puzzlenum = 0;

    public Transform target;
    public Transform parent;

    public Canvas pauseMenu;
    public Animator pauseMenuAnim;

    public bool paused = false;

    public Text gameCounter;
    public float startTimer;

    public Text scoreTable;
    public Text hiScoreTable;

    public int score = 0;
    public static int hiScore;

    public GameObject gameWinScreen;

    private ScriptPlayerData playerData;

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
       scoreTable = GameObject.Find( "scoreTable" ).GetComponent<Text>();
       hiScoreTable = GameObject.Find( "hiScoreTable" ).GetComponent<Text>();
       hiScoreTable.text = hiScore.ToString();
       gameWinScreen = GameObject.Find( "Voittoruutu" );
       gameWinScreen.SetActive( false );
       playerData = GameObject.Find( "PlayerData" ).GetComponent<ScriptPlayerData>();
       PlayerPrefs.SetInt("Metalli2HiScore",hiScore);
       if(PlayerPrefs.HasKey("Metalli2HiScore")) {
            hiScore = PlayerPrefs.GetInt("Metalli2HiScore");
        }

    }

    // Update is called once per frame
    void Update() 
    {
  
        startTimer += Time.deltaTime;

        if(startTimer < 1f) 
        {
            gameCounter.GetComponent<Text>().text = "";
        }

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

        if(Input.touchCount>0 && target.GetComponent<Target>().go == true) 
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
                    //jalki.transform.parent = parent.transform;
                } 

            }

            if (hit.transform.tag == "HitsausJalki") 
                {
                    if ( Input.touchCount > 0 ) 
                    {
                        touchParticle.SetActive( true );
                        touchParticle.transform.position = hit.point;
                        if(hit.transform.localScale.x < 1f) {
                            hit.transform.localScale += new Vector3( 0.1f, 0.1f, 0.1f )*Time.deltaTime;
                        } 
                    }
                }

            // Maybe try RayCastAll for hitting target as well?
                if (hit.transform.name == "Target") 
                {
                    if ( Input.touchCount > 0 ) 
                    {
                        touchParticle.SetActive( true );
                        touchParticle.transform.position = hit.point;
                        GameObject jalki = hitsausJalki;
                        Instantiate( jalki, new Vector3( hit.point.x, hit.point.y, -0.5f ), transform.rotation );
                        score += 1;
                        scoreTable.text = score.ToString();
                        //jalki.transform.parent = parent.transform;
                    }
                }
            }
        }
        else 
        {
            touchParticle.SetActive(false);
        }

        if(score > hiScore) {
            hiScore = score;
            hiScoreTable.text = "HI-SCORE: "+hiScore.ToString();
            PlayerPrefs.SetInt( "Metalli2HiScore", hiScore);
        }
    }

    public void Pause() 
    {
        if(!paused) {
            pauseMenu.enabled = true;
            paused = true;
            pauseMenuAnim.SetBool("Touched", true);
            target.GetComponent<Target>().go = false;
            
        }
        else {
            pauseMenu.enabled = false;
            paused = false;
            pauseMenuAnim.SetBool("Touched", false);
            target.GetComponent<Target>().go = true;
            
        }
        
    }

    public void NextPuzzle() 
    {
        if(puzzlenum<=1) 
        {
            hitsauskohteet[puzzlenum].SetActive( false );
            puzzlenum += 1;
            hitsauskohteet[puzzlenum].SetActive( true );
            target = GameObject.Find( "Target" ).transform;
            target.GetComponent<Target>().go = true;
            GameObject[] jalkis = GameObject.FindGameObjectsWithTag("HitsausJalki");

            for (int i=0; i<jalkis.Length; i++) 
            {
                jalkis[i].SetActive( false );
            }
        }
        else 
        {
            playerData.winMetalliMinipeli2 = true;
            target.GetComponent<Target>().go = false;
            target.gameObject.SetActive( false );
            GameObject.Find( "Text" ).SetActive( false );
            GameObject.Find( "OKButton" ).SetActive( false );
            gameWinScreen.SetActive( true );
        }


        //startTimer = 0f;
    }

    public static void SaveData() {
        //PlayerPrefs.SetInt("Metalli2HiScore",hiScore);
    }

    public void Retry() 
    {
        Application.LoadLevel("Minipeli2Metalli");
    }

    public void Menu() 
    {
        if(score > hiScore) 
        {
            score = hiScore;
            Application.LoadLevel("Metalliala");
        }
        
        else 
        {
            Application.LoadLevel("Metalliala");
        }
    }

    public void GameOver() 
    {

    }
}