using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedChecker : MonoBehaviour
{
   public bool IsGrounded;
   public Transform RaycastSource;
   public float Clearence;
   public LayerMask raycastLayer;

   public float CoyoteTime;

   private float coyoteTimer;

   private void Update()
   {
      Debug.DrawRay(RaycastSource.position, Vector2.down * Clearence);
      RaycastHit2D hit = Physics2D.Raycast(RaycastSource.position, Vector2.down, Clearence, raycastLayer);
      if(hit.collider != null)
      {
         IsGrounded = true;
         coyoteTimer = CoyoteTime;
      }
      else
      {
         if(coyoteTimer > 0)
         {
            IsGrounded = true;
            coyoteTimer -= Time.deltaTime;
         }
         else
         {
            IsGrounded = false;
         }
      }
   }

}
