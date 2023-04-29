using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
   public GameObject GameOver;
   public TMP_Text ReasonText;
   // Start is called before the first frame update
   void Start()
   {
      GameOver.SetActive(false);
   }

   // Update is called once per frame
   void Update()
   {

   }


   public void ShowGameOverMenu(string reason)
   {
      GameOver.SetActive(true);
      ReasonText.text = reason;
      Time.timeScale = 0;
   }

}
