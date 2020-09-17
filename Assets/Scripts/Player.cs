using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Examples.Pong
{
    public class Player : NetworkBehaviour
    {
        public float UpSpeed = 50.0f;
        public float LateralSpeed = 50.0f;
        //public GameObject[] Doors;

        Rigidbody2D rb;
        Vector3 pos;

        // Start is called before the first frame update
        void Start()
        {
            pos = transform.position;
            rb = GetComponent<Rigidbody2D>();
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

