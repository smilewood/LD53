using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
   public string BaseText;
   public int score = -1;
   private TMP_Text text;
   public TMP_Text GameOverMessage;
   [TextArea]
   public string GameOverString;

   // Start is called before the first frame update
   void Start()
   {
      text = GetComponentInChildren<TMP_Text>();
      FlagTriggerer.FlagTriggered.AddListener(UpdateScore);
      UpdateScore();
   }
   
   private void UpdateScore()
   {
      text.text = $"{BaseText}{++score}";
   }

   public void GameOver()
   {
      GameOverMessage.text = string.Format(GameOverString, score);
   }
}
