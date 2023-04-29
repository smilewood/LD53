using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls_Dash : MonoBehaviour
{
   public float SpeedBoost;
   public float BoostTime;

   public TileController map;

   public GameObject HeadCollider;

   private GroundedChecker grounded;
   private Controls_Jump jump;

   private float boostTimer;

   bool boosting = false;
   bool boosted = false;

   private void Start()
   {
      grounded = this.GetComponent<GroundedChecker>();
      jump = this.GetComponent<Controls_Jump>();
   }

   // Update is called once per frame
   void Update()
   {
      if (!boosting && !boosted && Input.GetButtonDown("Boost"))
      {
         map.speed += SpeedBoost;
         boostTimer = 0;
         boosting = true;
         boosted = true;
         //TODO: Play the animation
         HeadCollider.SetActive(false);

         jump.Dash(BoostTime);
      }

      if (boosting)
      {
         if (boostTimer > BoostTime)
         {
            map.speed -= SpeedBoost;
            HeadCollider.SetActive(true);
            boosting = false;
         }
         else
         {
            boostTimer += Time.deltaTime;
         }
      }

      if (boosted && grounded.IsGrounded)
      {
         boosted = false;
      }
   }
}
