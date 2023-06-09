using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileController : MonoBehaviour
{
   public float speed;
   public float Speedup;

   public Transform TileParent;
   public GameObject Tile1;

   public List<GameObject> TilePrefabs;

   public TMP_Text startText;

   public bool Disable;

   private Queue<GameObject> activeTiles;
   private int TileCount;
   // Start is called before the first frame update
   void Start()
   {
      if (Disable)
      {
         return;
      }
      if(TileParent == null)
      {
         TileParent = this.transform;
      }
      activeTiles = new Queue<GameObject>();

      GameObject tile;
      if(Tile1 != null)
      {
         tile = Tile1;
      }
      else
      {
         tile = Instantiate(PickRandomTile(), new Vector3(15f, 0, 0), Quaternion.identity, TileParent);
         tile.name = "Tile 1";
      }
      activeTiles.Enqueue(tile);
      TileCount = 1;

      AddTile(new Vector3(65, 0, 0));
      AddTile(new Vector3(115, 0, 0));

      StartCoroutine(StartDelay(speed));
      speed = 0;
   }

   // Update is called once per frame
   void Update()
   {
      if (Disable)
      {
         return;
      }
      foreach(GameObject tile in activeTiles)
      {
         tile.transform.position = tile.transform.position + new Vector3(speed, 0, 0) * Time.deltaTime;
      }
      if(activeTiles.Peek().transform.position.x < -50)
      {
         Destroy(activeTiles.Dequeue());
         AddTile(new Vector3(activeTiles.Peek().transform.position.x + 100, 0, 0));
         speed += Speedup;
      }
   }

   private void AddTile(Vector3 position)
   {
      GameObject tile = Instantiate(PickRandomTile(), position, Quaternion.identity, TileParent);
      tile.name = $"Tile {++TileCount}";
      activeTiles.Enqueue(tile);
   }

   private GameObject PickRandomTile()
   {
      return TilePrefabs[Random.Range(0, TilePrefabs.Count)];
   }


   private IEnumerator StartDelay(float StartSpeed)
   {
      for(int i = 3; i > 0; --i)
      {
         startText.text = $"{i}";
         yield return new WaitForSeconds(1);
      }
      startText.gameObject.SetActive(false);
      speed = StartSpeed;
   }

}
