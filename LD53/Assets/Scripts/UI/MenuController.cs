using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
   public Scorekeeper Scorekeeper;

   //public TMP_Text ReasonText;
   // Start is called before the first frame update
   void Start()
   {
   }

   // Update is called once per frame
   void Update()
   {

   }


   public void ShowGameOverMenu()
   {
      Scorekeeper.GameOver();
      MenuFunctions.Instance.ShowMenu("Game Over");
      MenuFunctions.PauseGame(false);
   }

}
