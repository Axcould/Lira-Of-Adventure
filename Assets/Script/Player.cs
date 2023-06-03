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
    public bool isGrounded;
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
        //Check Point
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, 0.1f, groundFloor);
        //Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
        }
    }
}
