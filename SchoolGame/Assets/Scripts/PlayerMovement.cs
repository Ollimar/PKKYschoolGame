using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10f;
    public float jumpVelocity = 10f;

    public bool isGrounded = false;

    public Transform circlePos;
    public float circleRadius = 1f;
    public LayerMask whatIsGround;

    private Transform myTransform;
    private Rigidbody2D myRB; 


	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        myTransform = this.transform;
	}
	
    void Update() {
        if(Input.GetButtonDown("Jump") && isGrounded) {
            Jump();
        }
    }

	void FixedUpdate () 
    {
        Move( Input.GetAxisRaw( "Horizontal" ) );
        isGrounded = Physics2D.OverlapCircle(circlePos.position,circleRadius,whatIsGround);
	}

    public void  Move(float horizontalInput) 
    {
        Vector2 moveVelocity = myRB.velocity;
        moveVelocity.x = horizontalInput * speed;
        myRB.velocity = moveVelocity;
    }

    public void Jump() {

        if(isGrounded) 
        {
            myRB.velocity += jumpVelocity * Vector2.up;
        }
    }
}
