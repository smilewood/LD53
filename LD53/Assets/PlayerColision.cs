using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
   [TagSelector]
   public string[] ColisionLayers;
   public MenuController menu;
   // Start is called before the first frame update
   void Start()
   {

   }
   private void OnCollisionEnter2D(Collision2D collision)
   {
      //Debug.Log($"{collision.collider.gameObject.name} collided with {collision.otherCollider.gameObject.name}");

      if(ColisionLayers.Any(l => collision.collider.CompareTag(l)))
      {
         Debug.LogError("Player Died");

         menu.ShowGameOverMenu($"{collision.otherCollider.gameObject.name} collided with {collision.collider.gameObject.name}");

      }
   }
}
