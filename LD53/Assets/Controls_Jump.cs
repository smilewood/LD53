using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls_Jump : MonoBehaviour
{
   public float JumpPower;
   public float JumpMaxTime;


   private Rigidbody2D rb;
   private float jumpTimer;
   private bool jumping;
   private GroundedChecker grounded;
   // Start is called before the first frame update
   void Start()
   {
      rb = this.GetComponent<Rigidbody2D>();
      grounded = this.GetComponent<GroundedChecker>();
   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetButtonDown("Jump") && grounded.IsGrounded)
      {
         jumping = true;
         jumpTimer = 0;
      }
      if (Input.GetButtonUp("Jump") || jumpTimer > JumpMaxTime)
      {
         jumping = false;
      }

      if (jumping)
      {
         jumpTimer += Time.deltaTime;
         rb.velocity = new Vector2(0, JumpPower);
      }
   }
}
