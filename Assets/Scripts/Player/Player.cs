using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]private float moveSpeed=7.5f;
    [Header("Ground Check")]
    [SerializeField]private float extraHeight=0.25f;
    [SerializeField]private LayerMask whatIsGround;
    [Header("Jump")]
    [SerializeField]private float jumpForce=5f;
    [SerializeField]private float jumpTime=0.5f;

    [Header("Turn Check")]
    [SerializeField]private GameObject lLeg;
    [SerializeField]private GameObject rLeg;

    [HideInInspector]public bool isFacingRight;
    private Animator anim;
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Collider2D coll;
    private float moveInput;

    private bool isJumping;
    private float jumpTimeCounter;
    private bool isFalling;

    private Coroutine resetTriggerCoroutine;

    private RaycastHit2D groundhit;

    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        coll=GetComponent<Collider2D>();
        StartDirectioncheck();
    }
    private void Update() // Changed from 'update' to 'Update'
    {
        Move();
        Jump();
    }

    #region Movement
    private void Move()
    {
       moveInput=UserInput.Instance.moveInput.x;
       if(moveInput>0 || moveInput<0)
       {
            anim.SetBool("IsWalking",true);
            TurnCheck();
       }
       else
       {
            anim.SetBool("IsWalking",false);
       }    
       rb.velocity=new Vector2(moveInput*moveSpeed,rb.velocity.y);
    }
    #endregion

    #region Ground/land Check
    private bool IsGrounded()
    {
        groundhit = Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,extraHeight,whatIsGround);
        if (groundhit.collider!=null)
        {
            return true;
        }
        return false;
    }
    private bool checkforland()
    {
        if(isFalling)
        {
            if(IsGrounded())
            {
                isFalling=false;
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    private IEnumerator Reset()
    {
        yield return null;
        anim.ResetTrigger("land");
    }
    #endregion

    
    
    #region Turn Check
    private void StartDirectioncheck()
    {
        if(rLeg.transform.position.x>lLeg.transform.position.x)
        {
            isFacingRight=true;
        }
        else
        {
            isFacingRight=false;
        }
    }
    private void TurnCheck()
    {
        if(UserInput.Instance.moveInput.x>0 && !isFacingRight)
        {
            Turn();
        }
        else if(UserInput.Instance.moveInput.x<0 && isFacingRight)
        {
            Turn();
        }
            
    }
    private void Turn()
    {
        if(isFacingRight)
        {
            Vector3 rotator = new Vector3(transform.rotation.x,180,transform.rotation.z);
            transform.rotation= Quaternion.Euler(rotator);
            isFacingRight=!isFacingRight;
        }
        else
        {
            Vector3 rotator = new Vector3(transform.rotation.x,0,transform.rotation.z);
            transform.rotation= Quaternion.Euler(rotator);
            isFacingRight=!isFacingRight;
        }
    }
    #endregion

 private void Jump()
 {
     if(UserInput.Instance.controls.Jumping.Jump.WasPressedThisFrame()&&IsGrounded())
     {
        isJumping=true;
        rb.velocity=new Vector2(rb.velocity.x,jumpForce);
        jumpTimeCounter=jumpTime;
        anim.SetTrigger("Jump");
       
     }
     if(UserInput.Instance.controls.Jumping.Jump.WasReleasedThisFrame())
     {
        isJumping=false;
        isFalling=true;
     }
     if(UserInput.Instance.controls.Jumping.Jump.IsPressed())
     {
        if(jumpTimeCounter>0&&isJumping)
        {
            rb.velocity=new Vector2(rb.velocity.x,jumpForce);
            jumpTimeCounter-=Time.deltaTime;
            
        }
        else if(jumpTimeCounter==0)
        {
            isFalling=true;
            isJumping=false;
        }
        else
        {
            isJumping=false;
        }   
     }
     if(!isJumping&& checkforland())
     {
        anim.SetTrigger("land");
        resetTriggerCoroutine=StartCoroutine(Reset());
     }
 }

}




