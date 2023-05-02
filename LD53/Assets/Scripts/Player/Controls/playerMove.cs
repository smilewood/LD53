using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
   public Vector2 move;
   public float speed;
   // Start is called before the first frame update
   void Start()
   {
      player = this.GetComponent<Rigidbody2D>();
   }

   // Update is called once per frame
   void Update()
   {
      move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed * Time.deltaTime;
   }
   Rigidbody2D player;
   private void FixedUpdate()
   {
      player.MovePosition(player.position + move);
   }
}
