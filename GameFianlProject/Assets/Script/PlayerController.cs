using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    public float doulbeJumpSpeed;
    
    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    private BoxCollider2D myFeet;
   
    private bool isGround;
    private bool canDoubleJump;
    private bool isJumping;
    private bool isFalling;
    private bool isDoubleJumping;
    private bool isDoubleFalling;

    private float playerGravity;

    private Vector2 move;
  
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.isGameAlive)
        {
            Flip();
            Run();
            Jump();
            //Attack();
            CheckGrounded();
            SwitchAnimation(); 
        }
            
       
    }
    void Run()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVel;
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnim.SetBool("Run", playerHasXAxisSpeed);
    }

    void Flip()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
        {
            if (myRigidbody.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0,0,0);
            }

            if (myRigidbody.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                myAnim.SetBool("Jump", true);
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRigidbody.velocity = Vector2.up *jumpVel;
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump)
                {
                    myAnim.SetBool("Jump", true);
                    Vector2 doubleJumpVel = new Vector2(0.0f,doulbeJumpSpeed);
                    myRigidbody.velocity = Vector2.up * doubleJumpVel;
                    canDoubleJump = false;
                }
            }
        }
    }

    void CheckGrounded()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Foreground"));
        //Debug.Log(isGround);
    }

    void SwitchAnimation()
    {
        myAnim.SetBool("Idle", false);
        if (myAnim.GetBool("Jump"))
        {
            if (myRigidbody.velocity.y < 0.0f)
            {
                myAnim.SetBool("Jump", false);
            }
        }
        else if(isGround)
        {
            myAnim.SetBool("Jump", false);
            myAnim.SetBool("Idle", true);
        }
    }

    /*void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            myAnim.SetTrigger("Attack");
        }
    }*/
}

