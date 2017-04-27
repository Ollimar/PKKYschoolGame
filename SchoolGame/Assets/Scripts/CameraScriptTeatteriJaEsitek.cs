using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScriptTeatteriJaEsitek : MonoBehaviour {

    public Transform target;
    public Transform camTargetY;

    public float smoothTime = 1f;
    public float cameraOffsetX = 5f;
    public float cameraDepth = -10f;
    public PlayerMovement playerMovement;

    public bool xPlus = true;
    public bool xMinus = false;

    public Image pauseButton;
    public bool paused;
    public Canvas pauseMenu;
    public Animator pauseMenuAnim;

    public Canvas dialogueCanvas;
    public Animator dialogueAnim;
    public Text dialogueText;
    public int dialogueLine = 0;

    public GameObject dialogueWin;

    //Stars for completed minigames
    public GameObject starCompleteMetalli1;
    public GameObject starCompleteMetalli2;
    public GameObject starCompleteMetalli3;

    private ScriptPlayerData playerData;
	
	void Start () 
    {
        dialogueCanvas = GameObject.Find( "_DialogueCanvas" ).GetComponent<Canvas>();
        playerData = GameObject.Find( "PlayerData" ).GetComponent<ScriptPlayerData>();
        target = GameObject.Find( "Player" ).transform;
        playerMovement = GameObject.Find( "Player" ).GetComponent<PlayerMovement>();
        playerMovement.canControl = false;
        playerMovement.GetComponentInChildren<CharacterCustomization>().enabled = false;

        pauseButton.enabled = false;
        pauseMenu.enabled = false;
        pauseMenuAnim = pauseMenu.GetComponentInChildren<Animator>();
        //pauseMenuAnim.SetBool("Touched",true);

        /*
        dialogueAnim = dialogueCanvas.GetComponentInChildren<Animator>();
        dialogueAnim.SetBool( "Touched", true );
        */

        if(playerData.metallialaVisits < 1) 
        {
            dialogueCanvas.enabled = true;
        }
        else 
        {
            dialogueCanvas.enabled = false;
            playerData.metallialaVisits += 1;
            playerMovement.canControl = true;
            pauseButton.enabled = true;
        }

        if(playerData.winMetalliMinipeli1 == true) 
        {
            dialogueWin.SetActive(true);
        }

        dialogueText.text = "Tervetuloa "+ playerData.playerName;

        GameObject[] stars;
        stars = GameObject.FindGameObjectsWithTag( "StarComplete" );

        for(int i=0; i< stars.Length; i++ ) 
        {
            stars[i].SetActive( false );
        }

        if(playerData.winMetalliMinipeli1 == true) 
        {
            starCompleteMetalli1.SetActive( true );
        }

        if(playerData.winMetalliMinipeli2 == true) 
        {
            starCompleteMetalli2.SetActive( true );
        }

	}
	
	
	void FixedUpdate () 
    {
        Vector3 playerPos = new Vector3(target.transform.position.x, transform.position.y, cameraDepth);
        Vector3 myPos = new Vector3(transform.position.x, camTargetY.position.y, transform.position.z);

        transform.position = Vector3.Lerp( myPos, new Vector3(myPos.x,playerMovement.camTargetY.position.y,myPos.z), smoothTime * Time.deltaTime );

        if(xPlus) 
        {
            playerPos.x = target.transform.position.x + cameraOffsetX;
            transform.position = Vector3.Lerp( myPos, playerPos, smoothTime * Time.deltaTime );
        }

        if (xMinus) 
        {
            playerPos.x = target.transform.position.x - cameraOffsetX;
            transform.position = Vector3.Lerp( myPos, playerPos, smoothTime * Time.deltaTime );
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

    public void ToMenu() {
        Application.LoadLevel( "WorldMap" );
    }

    public void NextText() 
    {
        print( "NextText" );
        dialogueLine += 1;
        
        if(dialogueLine == 1) {
            dialogueText.text = "Tervetuloa " + playerData.playerName;
        }

        if(dialogueLine == 2) {
            dialogueText.text = "Tervetuloa Teatteriin";
        }

        if (dialogueLine == 3) {
            dialogueText.text = "Aletaanpa hommiin!";
        }

        if (dialogueLine == 4) {
            dialogueCanvas.enabled = false;
            playerData.teatteriEsitekVisits += 1;
            playerMovement.canControl = true;
            pauseButton.enabled = true;
        }
        
    }

    public void DialogueOK() 
    {
        dialogueWin.SetActive( false );
    }
}
