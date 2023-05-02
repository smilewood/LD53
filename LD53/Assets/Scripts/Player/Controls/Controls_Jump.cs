using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls_Jump : MonoBehaviour
{
   public float JumpPower;
   public float JumpMaxTime;
   public float fallBoost;

   public bool DoubleJump;

   public Animator PlayerAnimator;

   private Rigidbody2D rb;
   private float jumpTimer;
   private bool jumping;
   private GroundedChecker grounded;
   private float normalGravity;
   private float fallingGravity;

   // Start is called before the first frame update
   void Start()
   {
      rb = this.GetComponent<Rigidbody2D>();
      grounded = this.GetComponent<GroundedChecker>();
      normalGravity = rb.gravityScale;
      fallingGravity = rb.gravityScale + fallBoost;
   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetButtonDown("Jump") && (grounded.IsGrounded || DoubleJump))
      {
         if (!grounded.IsGrounded)
         {
            DoubleJump = false;
         }

         jumping = true;
         jumpTimer = 0;
         PlayerAnimator.SetTrigger("Jump");
         SFXManager.Instance.PlayJump();
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

      if(grounded.IsGrounded && !DoubleJump)
      {
         DoubleJump = true;
      }

      if(!grounded.IsGrounded && rb.velocity.y < 0 && !Input.GetButton("Jump"))
      {
         rb.gravityScale = fallingGravity;
      }
      else
      {
         rb.gravityScale = normalGravity;
      }
      PlayerAnimator.SetFloat("Velocity", rb.velocity.y);
   }

   internal void Dash(float time)
   {
      StartCoroutine(DelayGravity(time));
   }
   private IEnumerator DelayGravity(float time)
   {
      float timer = 0;
      while (timer < time)
      {
         rb.velocity = new Vector2(rb.velocity.x, Math.Max(0, rb.velocity.y));
         timer += Time.deltaTime;
         yield return null;
      }
      DoubleJump = true;
   }
}
