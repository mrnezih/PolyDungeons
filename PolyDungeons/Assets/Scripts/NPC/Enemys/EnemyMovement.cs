using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    Animator anim;

    public bool isStatic;
    public bool isWalker;
    public bool isWalkingBack;
    public bool isPatroller;//devriye

    public Transform wallCheck, groundCheck, gabCheck;
    public bool wallDetected, groundDetected, gapDetected;
    public float detectionRaidus;
    public LayerMask whatIsGround;

    public Transform pointA, pointB;
    public bool moveToA, moveToB;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        moveToA = true;
    }

 
    void Update()
    {
        //gapDetected = !Physics2D.OverlapCircle(gabCheck.position, detectionRaidus, whatIsGround);
        wallDetected= Physics2D.OverlapCircle(wallCheck.position, detectionRaidus, whatIsGround);
        groundDetected= Physics2D.OverlapCircle(groundCheck.position, detectionRaidus, whatIsGround);

       


        if(gapDetected || wallDetected && groundDetected)
        {
            Flip();
        }
    }


    private void FixedUpdate()
    {
        if(isStatic)
        {
            anim.SetBool("Idle", true);
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        if(isWalker)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            anim.SetBool("Idle", false);
            if (!isWalkingBack)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
        }
        if(isPatroller)
        {
            anim.SetBool("Idle", false);
            if(moveToA)
            {
                rb.velocity=new Vector2(-speed * Time.deltaTime,rb.velocity.y);
                if(Vector2.Distance(transform.position,pointA.position)<0.2f)
                {
                    moveToA = false;
                    moveToB = true;
                }
            }
            if (moveToB)
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
                if (Vector2.Distance(transform.position, pointB.position) < 0.2f)
                {
                    moveToA = true;
                    moveToB = false;
                }
            }
        }
    }

    public void Flip()
    {
        isWalkingBack = !isWalkingBack;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
