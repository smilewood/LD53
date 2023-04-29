using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls_Dash : MonoBehaviour
{
   public float DashDistance;
   public float DashPullbackTime;
   public float SpeedBoost;
   public float BoostTime;

   public TileController map;

   private float boostTimer;

   // Start is called before the first frame update
   void Start()
   {
      //startPos = this.transform.position.x;
   }

   bool boosting = false;
   // Update is called once per frame
   void Update()
   {
      if (!boosting && Input.GetButtonDown("Boost"))
      {
         map.speed += SpeedBoost;
         boostTimer = 0;
         boosting = true;
      }
      if(boosting && boostTimer > BoostTime)
      {
         map.speed -= SpeedBoost;
         boosting = false;
      }
      boostTimer += boosting ? Time.deltaTime : 0;
   }
}
