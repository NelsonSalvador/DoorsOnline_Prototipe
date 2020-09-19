using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


namespace program
{
    public class Player : NetworkBehaviour
    {
        public float UpSpeed = 50.0f;
        public float LateralSpeed = 50.0f;

        GameObject networkMan;
        //public GameObject[] Doors;

        Rigidbody2D rb;
        Vector3 pos;

        NetworkScript script;

        // Start is called before the first frame update
        void Start()
        {
            pos = transform.position;
            rb = GetComponent<Rigidbody2D>();

            networkMan = GameObject.Find("NetWorkManager");

            script = networkMan.GetComponent<NetworkScript>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            
            // Movimento em x
            if (isLocalPlayer)
            {
                float hAxis = Input.GetAxis("Horizontal");

                Vector2 currentVelocity = rb.velocity;

                currentVelocity = new Vector2(hAxis * LateralSpeed, UpSpeed) * Time.fixedDeltaTime;

                rb.velocity = currentVelocity;
            }
            
        }

        

    }
}

