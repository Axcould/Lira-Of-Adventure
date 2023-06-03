using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float runSpeed;
    public Animator playerAnimator;
    private Rigidbody2D playerRigidbody;

    [Header("Jump")]
    public float jumpForce;
    public Transform groundcheck;
    private bool isGrounded;
    private bool doDoubleJump;
    public LayerMask groundFloor;
    // Start is called before the first frame update
    void Start()
    {
        //Get Component
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed, playerRigidbody.velocity.y);
        //Flipping Player
        if (playerRigidbody.velocity.x > 0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        else if (playerRigidbody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        //Check Point
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, 0.1f, groundFloor);
        //Jumping
        if (Input.GetButtonDown("Jump") && (isGrounded || doDoubleJump))
        {
            if (isGrounded)
            {
                doDoubleJump = true;
            }
            else
            {
                doDoubleJump = false;
                playerAnimator.SetTrigger("Double Jump");
            }
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
        }


        playerAnimator.SetBool("IsGrounded", isGrounded);
        playerAnimator.SetFloat("Speed", Mathf.Abs(playerRigidbody.velocity.x));
    }
}
