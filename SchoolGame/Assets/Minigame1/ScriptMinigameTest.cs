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

    public float maxX;
    public float maxY;
    public float minX;
    public float minY;

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

    public float timer;                                                     //The game's global timer
    public float startTimer;                                                //Countdown for when the game starts
    public float timeMultiplier = 150f;                                     //How fast the timer bar reduces
    public Text gameCounter;                                                //Text for dispalying the game start countdown
    public bool startGame = false;

    public bool paused = false;
    public bool win = false;

    // Variables for Game Over Screen
    public GameObject   gameOverImage;
    public Text         yourScore;
    public Text         yourBest;

    // Variables for Game Win Screen
    public GameObject   gameWinImage;
    public Text         yourScoreWin;
    public Text         yourBestWin;

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
        gameCounter = GameObject.Find( "StartCountDown" ).GetComponent<Text>();
        //hiScore = playerData.scoreMetalliMinipeli1 = hiScore;
        PlayerPrefs.GetInt( "MetalliMinipeli1HiScore", hiScore );
	}
	
	// Update is called once per frame
	void Update () 
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
            startGame = true;
        }

        if(startGame) {
            timer += Time.deltaTime;
        }

        if(!paused && !win && startGame) 
        {
            bar.fillAmount -= Time.deltaTime/timeMultiplier;
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

            if(score > hiScore) 
            {
                //playerData.scoreMetalliMinipeli1 = hiScore;
                PlayerPrefs.SetInt("MetalliMinipeli1HiScore", hiScore);
                PlayerPrefs.GetInt( "MetalliMinipeli1HiScore", hiScore );
                PlayerPrefs.Save();
                yourScoreWin.text = score.ToString();
                yourBestWin.text = hiScore.ToString();
            }
                PlayerPrefs.GetInt( "MetalliMinipeli1HiScore", hiScore );
                yourScoreWin.text = score.ToString();
                yourBestWin.text = hiScore.ToString();
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
            numbers[0].transform.localPosition = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
            parsec1 = false;
            timer = 0f;
            tapCount = 1;

        }

        if(timer >= interval1 && timer < interval2 && parsec2 == true && parsec1 == false) 
        {
            numbers[0].SetActive( true );
            numbers[0].transform.localPosition = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
            numbers[0].GetComponent<NumberButtonScript>().timer = 0f;
            parsec2 = false;
            timer = 0f;
            tapCount = 1;
        }

        if(timer >= interval1 && timer < interval2 && parsec3 == true && parsec2 == false) 
        {
            numbers[0].SetActive( true );
            numbers[0].transform.localPosition = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
            numbers[0].GetComponent<NumberButtonScript>().timer = 0f;
            parsec3 = false;
            timer = 0f;
            tapCount = 1;
        }

        if(timer >= interval1 && timer < interval2 && parsec4 == true && parsec3 == false) 
        {
            numbers[0].SetActive( true );
            numbers[0].transform.localPosition = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
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
            startGame = false;
            
            //Time.timeScale = 0f;
        }
        else {
            pauseMenu.enabled = false;
            paused = false;
            pauseMenuAnim.SetBool("Touched", false);
            startGame = true;
            
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
            PlayerPrefs.SetInt("MetalliMinipeli1HiScore", hiScore);
            //PlayerPrefs.GetInt( "MetalliMinipeli1HiScore", hiScore );
            PlayerPrefs.Save();
            yourScore.text = "SCORE: "+score.ToString();
            yourBest.text = "HI-SCORE: "+hiScore.ToString();
            //playerData.scoreMetalliMinipeli1 = hiScore;
            
        }
        else 
        {
            //PlayerPrefs.GetInt( "MetalliMinipeli1HiScore", hiScore );
            yourScore.text = "SCORE: "+score.ToString();
            yourBest.text = "HI-SCORE: "+hiScore.ToString();
        }
    }

    public void Retry() 
    {
        Application.LoadLevel("Minipeli1Metalli");
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
