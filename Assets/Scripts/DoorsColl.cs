using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Examples.Pong
{
    public class DoorsColl : NetworkBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Finish")
            {
                collision.gameObject.transform.position = new Vector3(0, -5, 10);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                
                gameObject.SetActive(false);
            }
        }
    }
}

