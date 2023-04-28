using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager manager;
    
    private Vector3 initialPosition;
    
    public float WalkSpeed;
    public float JumpForce;

    public Rigidbody Rigidbody;

    public bool onGround;
    public bool disableControls;
    void Start()
    {
        initialPosition = transform.position;
    }

  
    void FixedUpdate()
    {
        if (!disableControls)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Move(true);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Move(false);
            }
            if (Input.GetKey(KeyCode.Space) && onGround)
            {
                Jump();
            }
        }
    }

    void Move(bool moveLeft)
    {
        if (moveLeft)
        {
            transform.Translate(Vector3.left*WalkSpeed);
        }
        else
        {
            transform.Translate(Vector3.right*WalkSpeed);
        }
    }

    void Jump()
    {
        Rigidbody.AddForce(Vector3.up*JumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            manager.ShowRestartScreen();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            manager.ShowFinishScreen();
        }
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }

    public void ReturnToSpawn()
    {
        transform.position = initialPosition;
    }
}
