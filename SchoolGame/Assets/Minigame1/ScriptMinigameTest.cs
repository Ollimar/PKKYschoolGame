using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptMinigameTest : MonoBehaviour {


    public int score = 0;
    public int hiScore = 1000;
    public int scoreToBeat = 10000;
    public Text scoreText;

    public int tapCount = 1;

    public GameObject[] numbers;
    public GameObject[] transitions;

    public GameObject touchParticle;

    public bool isHolding = false;

    public float interval1 = 5f;
    public float interval2 = 10f;

    public bool parsec1 = true;
    public bool parsec2 = true;
    public bool parsec3 = true;

    public float timer;

    public bool paused = false;
    public bool win = false;

    // Variables for Game Over Screen
    public GameObject gameOverImage;
    public GameObject gameWinImage;
    public Text yourScore;
    public Text yourBest;

    // Variables for pause menu
    public Canvas pauseMenu;
    public Animator pauseMenuAnim;

    public Image bar;

    private ScriptPlayerData playerData;

	// Use this for initialization
	void Start () {
        pauseMenu = GameObject.Find( "PauseCanvas" ).GetComponent<Canvas>();
        pauseMenu.enabled = false;
        gameOverImage.SetActive(false);
        playerData = GameObject.Find( "PlayerData" ).GetComponent<ScriptPlayerData>();
        yourBest.text = playerData.scoreMetalliMinipeli1.ToString();
        gameWinImage.SetActive( false );
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;

        if(!paused && !win) 
        {
            bar.fillAmount -= Time.deltaTime/50f;
        }

        if(bar.fillAmount <= 0f) 
        {
            GameOver();
        }

        if(score >= scoreToBeat) 
        {
            win = true;
        }

        if(win) 
        {
            gameWinImage.SetActive( true );
        }

        Ray ray;
        RaycastHit hit;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity)) 
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

        if(timer >= interval1 && timer < interval2 && parsec1 == true) 
        {
            numbers[0].SetActive( true );
            numbers[1].SetActive( true );
            numbers[2].SetActive( true );
            parsec1 = false;
            timer = 0f;
        }

        if(timer >= interval1 && timer < interval2 && parsec2 == true && parsec1 == false) 
        {
            numbers[3].SetActive( true );
            numbers[4].SetActive( true );
            numbers[5].SetActive( true );
            parsec2 = false;
            timer = 0f;
        }

        if(timer >=interval1 && timer < interval2 && parsec3 == true &&  parsec2 == false) 
        {
            transitions[0].SetActive( true );
            numbers[6].SetActive( true );
            numbers[7].SetActive( true );
            parsec1 = true;
            parsec2 = true;
            parsec3 = true;
            timer = 0f;
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

    public void GameOver() 
    {
        // Bring out the menu letting player to either retry or quit the game and return to title screen
        gameOverImage.SetActive(true);

        if(score > hiScore) 
        {
            hiScore = score;
            yourScore.text = "SCORE: "+score.ToString();
            yourBest.text = "HI-SCORE: "+hiScore.ToString();
            playerData.scoreMetalliMinipeli1 = hiScore;
        }
        else 
        {
            yourScore.text = "SCORE: "+score.ToString();
            yourBest.text = "HI-SCORE: "+hiScore.ToString();
        }
    }

    public void Retry() {

        Application.LoadLevel("MinigameTest");
    }

    public void Quit() 
    {
        // Saves the player's hi-score and returns to "Metalliala" scene
        Application.LoadLevel("Metalliala");
    }

    public void Win() 
    {
        playerData.winMetalliMinipeli1 = true;
        Application.LoadLevel("Metalliala");
    }
}
