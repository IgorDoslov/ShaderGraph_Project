using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float jumpForce = 10.0f;
    public Rigidbody rb;
    public Animator anim;
    

    public bool Grounded
    {
        get
        {
            return anim.GetBool("IsGrounded");
        }
        set
        {
            anim.SetBool("IsGrounded", value);
        }
    }
    
    public bool Falling
    {
        get 
        {
            if (!Grounded && !CanJump())
                return true;
            else
                return false;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CanJump();
        Move();
        if(Falling)
        {
            Grounded = false;
            anim.SetBool("IsJumping", false);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    void Move()
    {
        if (PauseMenu.gameIsPaused == true)
            return;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        anim.SetFloat("Xpos", x);
        anim.SetFloat("Ypos", z);
        Vector3 dir = transform.right * x + transform.forward * z;
        dir *= moveSpeed;
        dir.y = rb.velocity.y;

        rb.velocity = dir;
    }

    void Jump()
    {
        if (CanJump())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetBool("IsJumping", true);
            Grounded = false;
        }
    }

    bool CanJump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1.5f))
        {
            Grounded = true;
            anim.SetBool("IsJumping", false);
            return true; //hit.collider != null;
        }
        //anim.SetBool("IsJumping", false);
        Grounded = false;
        return false;
    }

}
