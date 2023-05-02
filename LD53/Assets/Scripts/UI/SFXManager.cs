using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

   public AudioSource Run, Dash, Die, Jump, Flag;

   public static SFXManager Instance;

   private void Start()
   {
      if(Instance == null)
      {
         Instance = this;
         FlagTriggerer.FlagTriggered.AddListener(PlayFlag);
         DontDestroyOnLoad(this.gameObject);
         return;
      }
      Destroy(this);

   }


   public void PlayDash()
   {
      Dash.Play();
   }

   public void PlayDie()
   {
      Die.Play();
   }
   public void PlayJump()
   {
      Jump.Play();
   }
   public void PlayFlag()
   {
      Flag.Play();
   }

   public void PlayRun(bool grounded)
   {
      if (!grounded)
      {
         Run.Pause();
      }
      else
      {
         Run.UnPause();
      }
   }
}
