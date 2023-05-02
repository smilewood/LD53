using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerColision : MonoBehaviour
{
   [TagSelector]
   public string[] ColisionLayers;
   public MenuController menu;

   private bool safe = false;
   public float SafeTime;

   private void OnCollisionEnter2D(Collision2D collision)
   {
      //Debug.Log($"{collision.collider.gameObject.name} collided with {collision.otherCollider.gameObject.name}");

      if(!safe && ColisionLayers.Any(l => collision.collider.CompareTag(l)))
      {
         Debug.LogError("Player Died");
         SFXManager.Instance.PlayDie();
         menu.ShowGameOverMenu();
      }
   }
   private void OnEnable()
   {
      safe = true;
      StartCoroutine(SaftyDelay());
   }

   private IEnumerator SaftyDelay()
   {
      yield return new WaitForSeconds(SafeTime);
      safe = false;
   }
}
