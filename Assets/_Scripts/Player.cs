using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    [SerializeField]
    private float jumpForce = 5.0f;

    private bool resetJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();   
    }

    void Movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rigidBody2D.velocity = new Vector2(move, rigidBody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() == true)
        {
            Debug.Log("JUMP");
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpForce);
            StartCoroutine(ResetJumpRoutine());
        }
        else
        {
            Debug.Log("False");
        }
    }

    bool IsGrounded()
    {
      RaycastHit2D hitInfo =   Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << 8);
      if (hitInfo.collider != null)
      {
          Debug.Log("Message");
          if (resetJump == false)
          {
              return true;
          } ;
      }

      return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        resetJump = true;
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }

}
