using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Mirror.Examples.Pong
{
    public class Doors : NetworkBehaviour
    {
        public GameObject[] Doors1;
        public GameObject[] Doors2;
        public GameObject[] Doors3;

        int doorOpen_1;
        int doorOpen_2;
        int doorOpen_3;
        // Start is called before the first frame update

        public override void OnStartServer()
        {
            base.OnStartServer();

            System.Random rand = new System.Random();

            doorOpen_1 = rand.Next(Doors1.Length);
            doorOpen_2 = rand.Next(Doors2.Length);
            doorOpen_3 = rand.Next(Doors3.Length);

            Doors1[doorOpen_1].GetComponent<BoxCollider2D>().isTrigger = true;
            Doors2[doorOpen_2].GetComponent<BoxCollider2D>().isTrigger = true;
            Doors3[doorOpen_3].GetComponent<BoxCollider2D>().isTrigger = true;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Finish")
            {
                collision.gameObject.transform.position = new Vector3(0, 5, 10);
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

