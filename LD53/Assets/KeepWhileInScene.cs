using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeepWhileInScene : MonoBehaviour
{
   private string scene;
   private static bool loaded;

   // Start is called before the first frame update
   void Start()
   {
      if (!loaded)
      {
         DontDestroyOnLoad(this.gameObject);
         SceneManager.sceneLoaded += OnSceneLoad;
         scene = SceneManager.GetActiveScene().name;
         loaded = true;
      }
      else
      {
         Destroy(this.gameObject);
      }
   }

   private void OnSceneLoad(Scene scene, LoadSceneMode mode)
   {
      if(scene.name != this.scene)
      {
         Destroy(this.gameObject);
         loaded = false;
      }
   }
   // Update is called once per frame
   void Update()
   {

   }
}
