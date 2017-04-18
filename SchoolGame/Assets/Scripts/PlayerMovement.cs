using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10f;
    public float jumpVelocity = 10f;

    public bool canControl = true;
    public bool facingRight = true;
    public bool isGrounded = false;
    public bool canMoveInAir = true;

    public bool canEnterMetalliala = false;
    public bool canEnterTeatteriJaEsitysTekniikka = false;

    // Variables for handling collision
    public Transform circlePos;
    public float circleRadius = 1f;
    public LayerMask whatIsGround;

    private Transform myTransform;
    private Rigidbody2D myRB;
    private CameraScript cameraScript;

    public Transform maxCam;
    public Transform minCam;
    public float camDistance = 1f;
    public Transform camTargetY;
    public float yOffset = 3f;
    public Transform targetPoint;

    float hInput = 0f;


	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        myTransform = this.transform;
        maxCam = GameObject.Find( "MaxCam" ).transform;
        minCam = GameObject.Find( "MinCam" ).transform;
        cameraScript = GameObject.Find( "Main Camera" ).GetComponent<CameraScript>();

	}
	
    void Update() 
        {

        camTargetY.position = Vector3.Lerp(camTargetY.position,new Vector3(targetPoint.position.x,targetPoint.position.y+yOffset,targetPoint.position.z),4f*Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded) {
            Jump();
        }

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

        if(isGrounded && canControl) 
        {
            myRB.velocity += jumpVelocity * Vector2.up;

            if (canEnterMetalliala) {
                Application.LoadLevel("MinigameTest");
            }
            if(canEnterTeatteriJaEsitysTekniikka) {
                Application.LoadLevel("MinigameTeatterJaEsitysTekniikka");
            }
        }
    }

    public void StartMoving(float horizontalInput) 
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if(hor > 0.1 && !facingRight) {
            Flip();
        }

        if(hor < -0.1 && facingRight) {
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
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "MetallialaTriggerBox") {
            canEnterMetalliala = false;
        }

        if(other.gameObject.name == "TeatteriJaEsitystekniikkaTriggerBox") {
            canEnterTeatteriJaEsitysTekniikka = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "ground") {
            targetPoint.position = other.transform.position;
        }
    }
}
