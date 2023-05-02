using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlagEvent : UnityEvent { }

public class FlagTriggerer : MonoBehaviour
{
   public static FlagEvent FlagTriggered;

   private void Awake()
   {
      if(FlagTriggered == null)
      {
         FlagTriggered = new FlagEvent();
      }
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject.CompareTag("Flag"))
      {
         FlagTriggered.Invoke();
         collision.gameObject.GetComponent<Flag>().FlagTriggered();
      }
   }
}
