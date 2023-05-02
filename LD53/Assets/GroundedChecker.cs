using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedChecker : MonoBehaviour
{
   public bool IsGrounded;
   public Transform RaycastSource;
   public float Clearence;
   public LayerMask raycastLayer;
   public Animator PlayerAnimator;
   public float CoyoteTime;

   private float coyoteTimer;

   private void Update()
   {
      Debug.DrawRay(RaycastSource.position, Vector2.down * Clearence);
      RaycastHit2D hit = Physics2D.Raycast(RaycastSource.position, Vector2.down, Clearence, raycastLayer);
      if(hit.collider != null)
      {
         if (!IsGrounded)
         {
            IsGrounded = true;
            coyoteTimer = CoyoteTime;
            SFXManager.Instance.PlayRun(true);
            PlayerAnimator.SetBool("Grounded", true);
         }
      }
      else
      {
         if(coyoteTimer > 0)
         {
            coyoteTimer -= Time.deltaTime;
         }
         else if(IsGrounded)
         {
            {
               IsGrounded = false;
               SFXManager.Instance.PlayRun(false);
               PlayerAnimator.SetBool("Grounded", false);
            }
         }
      }
   }

}
