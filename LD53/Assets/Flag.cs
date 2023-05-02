using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
   public GameObject FlagActive, FlagInactive;

   public void FlagTriggered()
   {
      FlagActive.SetActive(true);
      FlagInactive.SetActive(false);
   }

}
