using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BackgroundMoover : MonoBehaviour
{
   public float BorderDistance;
   public float SpeedModifier;
   public List<GameObject> Prefabs;
   public float VOffset;
   public TileController Foreground;

   private Queue<GameObject> activeTiles;

   private void Start()
   {
      activeTiles = new Queue<GameObject>();
      foreach(Transform child in transform)
      {
         activeTiles.Enqueue(child.gameObject);
      }
   }

   // Update is called once per frame
   void Update()
   {
      foreach (GameObject tile in activeTiles)
      {
         tile.transform.position = tile.transform.position + new Vector3(Foreground.speed * SpeedModifier, 0, 0) * Time.deltaTime;
      }

      if (activeTiles.Peek().transform.localPosition.x < BorderDistance)
      {
         Destroy(activeTiles.Dequeue());
         AddTile(new Vector3(activeTiles.Peek().transform.localPosition.x + 48, Random.Range(0, VOffset), 0));
      }
   }
   private int TileCount = 2;
   private void AddTile(Vector3 position)
   {
      GameObject tile = Instantiate(PickRandomTile(), this.transform);
      tile.transform.localPosition = position;
      tile.name = $"{this.gameObject.name} {++TileCount}";
      activeTiles.Enqueue(tile);
   }

   private GameObject PickRandomTile()
   {
      return Prefabs[Random.Range(0, Prefabs.Count)];
   }
}
