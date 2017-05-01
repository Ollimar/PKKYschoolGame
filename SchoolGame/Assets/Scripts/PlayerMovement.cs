using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10f;
    public float jumpVelocity = 10f;
    public int   jumpCount = 0;

    public bool canControl = true;
    public bool facingRight = true;
    public bool isGrounded = false;
    public bool canMoveInAir = true;

    public bool canEnterMetalliala = false;
    public bool canEnterTeatteriJaEsitysTekniikka = false;
    public bool canEnterTeatteriJaEsitysTekniikkaMG1 = false;

    // Variables for handling collision
    public Transform circlePos;
    public float circleRadius = 1f;
    public LayerMask whatIsGround;

    private Transform myTransform;
    private Rigidbody2D myRB;
    private CameraScript cameraScript;
    private Animator myAnim;
    private ScriptPlayerData playerData;

    public Transform maxCam;
    public Transform minCam;
    public float camDistance = 1f;
    public Transform camTargetY;
    public float yOffset = 3f;
    public Transform targetPoint;

    public GameObject[] platforms;
    public GameObject[] hats;

    public GameObject playerGraphics;

    public int hatNumber;

    float hInput = 0f;


	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        myTransform = this.transform;
        maxCam = GameObject.Find( "MaxCam" ).transform;
        minCam = GameObject.Find( "MinCam" ).transform;
        cameraScript = GameObject.Find( "Main Camera" ).GetComponent<CameraScript>();
        platforms = GameObject.FindGameObjectsWithTag("Platform");
        myAnim = GetComponentInChildren<Animator>();
        playerData = GameObject.Find( "PlayerData" ).GetComponent<ScriptPlayerData>();
        hatNumber = playerData.hatNumber;

        if(hatNumber == 1) {
            hats[0].SetActive( true );
            hats[1].SetActive(false);
        }

        if(hatNumber == 2) {
            hats[0].SetActive( false );
            hats[1].SetActive(true);
        }


	}
	
    void Update() 
        {

        camTargetY.position = Vector3.Lerp(camTargetY.position,new Vector3(targetPoint.position.x,targetPoint.position.y+yOffset,targetPoint.position.z),4f*Time.deltaTime);
        if(myRB.velocity.x != 0f) {
            myAnim.SetBool( "run", true );
        }
        else {
            myAnim.SetBool("run", false);
        }

        if(Input.GetButtonDown("Jump") && isGrounded) {
            Jump();
        }

        myAnim.SetFloat( "yVelocity", myRB.velocity.y );
        myAnim.SetBool( "grounded", isGrounded );
        myAnim.SetBool( "Jump", !isGrounded );

        if(this.transform.position.x >= maxCam.position.x) {
            maxCam.position = new Vector3(transform.position.x, maxCam.position.y, maxCam.position.z);
            minCam.position = new Vector3( maxCam.position.x - camDistance, minCam.position.y, minCam.position.z );
            cameraScript.xPlus = true;
            cameraScript.xMinus = false;
        }

        if(this.transform.position.x <= minCam.position.x) {
            minCam.position =  new Vector3(transform.position.x, maxCam.position.y, maxCam.position.z);
            maxCam.position = new Vector3( minCam.position.x + camDistance, minCam.position.y, minCam.position.z );
            cameraScript.xPlus = false;
            cameraScript.xMinus = true;
        }
        else if(this.transform.position.x < maxCam.position.x && this.transform.position.x > minCam.position.x){
            cameraScript.xPlus = false;
            cameraScript.xMinus = false;
        }
    }

	void FixedUpdate () 
    {
        isGrounded = Physics2D.OverlapCircle(circlePos.position,circleRadius,whatIsGround);

        if(isGrounded) 
        {
            jumpCount = 0;
        }

        if(canControl) 
        {
        #if !UNITY_ANDROID
        Move( Input.GetAxisRaw( "Horizontal" ) );
        if(Input.GetAxisRaw( "Horizontal" ) > 0.1 && !facingRight) {
            Flip();
        }

        if(Input.GetAxisRaw( "Horizontal" ) < -0.1 && facingRight) {
            Flip();
        }
        #else
        Move( hInput );
        #endif
        }
    }

    void  Move(float horizontalInput) 
    {
        if ( !canMoveInAir && !isGrounded )
            return;

        Vector2 moveVelocity = myRB.velocity;
        moveVelocity.x = horizontalInput * speed;
        myRB.velocity = moveVelocity;

        if(horizontalInput > 0.1 && !facingRight) {
            Flip();
        }

        if(horizontalInput < -0.1 && facingRight) {
            Flip();
        }
    }

    public void Jump() {

        if(isGrounded && canControl && jumpCount <1) 
        {
            print( "Jump" );
            myRB.velocity += jumpVelocity * Vector2.up;
            jumpCount += 1;

            if (canEnterMetalliala) {
                Application.LoadLevel("Minipeli1Metalli");
            }

            if(canEnterTeatteriJaEsitysTekniikka) {
                Application.LoadLevel("Minipeli2Metalli");
            }

            if(canEnterTeatteriJaEsitysTekniikkaMG1) {
                Application.LoadLevel("Minipeli1TeatterijaEsitysTekniikka");
            }
        }
    }

    public void StartMoving(float horizontalInput) 
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if(hor > 0.1 && !facingRight) {
            playerGraphics.transform.Rotate( Vector3.up * 270f );
            Flip();
        }

        if(hor < -0.1 && facingRight) {
           playerGraphics.transform.Rotate(Vector3.up*270f);
           Flip();
        }
        hInput = horizontalInput;
    }

    void Flip() 
    {
        facingRight = !facingRight;
        transform.Rotate( Vector3.up * 180f );  
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "MetallialaTriggerBox") {
            canEnterMetalliala = true;
        }

        if(other.gameObject.name == "TeatteriJaEsitystekniikkaTriggerBox") {
            canEnterTeatteriJaEsitysTekniikka = true;
        }

        if(other.gameObject.name == "TeatteriJaEsitystekniikkaMG1") {
            canEnterTeatteriJaEsitysTekniikkaMG1 = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "MetallialaTriggerBox") {
            canEnterMetalliala = false;
        }

        if(other.gameObject.name == "TeatteriJaEsitystekniikkaTriggerBox") {
            canEnterTeatteriJaEsitysTekniikka = false;
        }

        if(other.gameObject.name == "TeatteriJaEsitystekniikkaMG1") {
            canEnterTeatteriJaEsitysTekniikkaMG1 = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Platform") {
            targetPoint.position = other.transform.position;
        }
    }
}
