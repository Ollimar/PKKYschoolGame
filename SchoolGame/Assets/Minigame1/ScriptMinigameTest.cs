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
    public bool parsec4 = true;
    public bool parsec5 = true;
    public bool parsec6 = true;
    public bool parsec7 = true;
    public bool parsec8 = true;
    public bool parsec9 = true;
    public bool parsec10 = true;
    public bool parsec11 = true;
    public bool parsec12 = true;
    public bool parsec13 = true;
    public bool parsec14 = true;

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
            bar.fillAmount -= Time.deltaTime/100f;
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
            parsec1 = false;
            timer = 0f;
            tapCount = 1;

        }

        if(timer >= interval1 && timer < interval2 && parsec2 == true && parsec1 == false) 
        {
            numbers[0].SetActive( true );
            numbers[0].GetComponent<NumberButtonScript>().timer = 0f;
            parsec2 = false;
            timer = 0f;
            tapCount = 1;
        }

        if(timer >= interval1 && timer < interval2 && parsec3 == true && parsec2 == false) 
        {
            numbers[0].SetActive( true );
            numbers[0].GetComponent<NumberButtonScript>().timer = 0f;
            parsec3 = false;
            timer = 0f;
            tapCount = 1;
        }

        if(timer >= interval1 && timer < interval2 && parsec4 == true && parsec3 == false) 
        {
            numbers[0].SetActive( true );
            numbers[0].GetComponent<NumberButtonScript>().timer = 0f;
            parsec4 = false;
            timer = 0f;
            tapCount = 1;
        }

        if(timer >=interval1 && timer < interval2 && parsec5 == true &&  parsec4 == false) 
        {
            tapCount = 1;
            numbers[0].SetActive( true );
            numbers[0].GetComponent<NumberButtonScript>().timer = 0f; 
            numbers[0].GetComponent<RectTransform>().localPosition = new Vector2( -249f, 0f );  
            numbers[1].SetActive( true );
            numbers[2].SetActive( true );
            parsec5 = false;
            timer = 0f;
        }

        if(timer >=interval1 && timer < interval2 && parsec6 == true &&  parsec5 == false) 
        {
            numbers[3].SetActive( true ); 
            numbers[3].GetComponent<NumberButtonScript>().timer = 0f;
            numbers[4].SetActive( true );
            numbers[5].SetActive( true );
            parsec6 = false;
            timer = 0f;
        }

        if(timer >=9 && timer < interval2 && parsec7 == true &&  parsec6 == false) 
        {
            tapCount = 1;
            numbers[0].SetActive( true );
            numbers[0].GetComponent<NumberButtonScript>().timer = 0f; 
            numbers[0].GetComponent<RectTransform>().localPosition = new Vector2( 249f, 0f );
            numbers[1].SetActive( true );
            numbers[1].GetComponent<NumberButtonScript>().timer = 0f;
            numbers[1].GetComponent<NumberButtonScript>().transition = true;
            numbers[1].GetComponent<RectTransform>().localPosition = new Vector2( -249f, 0f ); 
            for(int i = 0; i < transitions.Length; i++ ) 
            {
                transitions[i].SetActive( true );
                transitions[i].GetComponent<TransitionButtonScript>().goalNumber = numbers[1];
            }
            parsec7 = false;
            timer = 0f;
            tapCount = 1;
        }

        if(timer >=interval1 && timer < interval2 && parsec8 == true &&  parsec7 == false) 
        {

            win = true;

            /*
            tapCount = 1;
            numbers[0].SetActive( true );
            numbers[0].GetComponent<NumberButtonScript>().timer = 0f; 
            numbers[0].GetComponent<RectTransform>().localPosition = new Vector2( -249f, -372f );
            numbers[1].SetActive( true );
            numbers[1].GetComponent<NumberButtonScript>().transitions = 0;
            numbers[1].GetComponent<NumberButtonScript>().timer = 0f;
            numbers[1].GetComponent<NumberButtonScript>().transition = true;
            numbers[1].GetComponent<RectTransform>().localPosition = new Vector2( 249f, -372f ); 

            for(int i = 0; i < transitions.Length; i++ ) 
            {
                transitions[i].SetActive( true );
                transitions[i].GetComponent<TransitionButtonScript>().goalNumber = numbers[1];
            }

            transitions[0].GetComponent<TransitionButtonScript>().transitionNumber = 0;
            transitions[1].GetComponent<TransitionButtonScript>().transitionNumber = 1;
            transitions[2].GetComponent<TransitionButtonScript>().transitionNumber = 2;
            transitions[3].GetComponent<TransitionButtonScript>().transitionNumber = 3;

            transitions[0].GetComponent<RectTransform>().localPosition = new Vector2(GetComponent<RectTransform>().localPosition.x, -539f);
            transitions[1].GetComponent<RectTransform>().localPosition = new Vector2(GetComponent<RectTransform>().localPosition.x, -539f);
            transitions[2].GetComponent<RectTransform>().localPosition = new Vector2(GetComponent<RectTransform>().localPosition.x, -539f);
            transitions[3].GetComponent<RectTransform>().localPosition = new Vector2(GetComponent<RectTransform>().localPosition.x, -539f);

            parsec8 = false;
            timer = 0f;
            tapCount = 1;
            */
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

    public void Retry() 
    {
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
