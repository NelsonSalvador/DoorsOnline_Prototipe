using UnityEngine;
using Mirror;

namespace program
{
    // Custom NetworkManager that simply assigns the correct racket positions when
    // spawning players. The built in RoundRobin spawn method wouldn't work after
    // someone reconnects (both players would be on the same side).
    [AddComponentMenu("")]
    public class NetworkScript : NetworkManager
    {
        public Transform leftRacketSpawn;
        public Transform rightRacketSpawn;

        public GameObject[] Doors1;
        public GameObject[] Doors2;
        public GameObject[] Doors3;

        //public GameObject DoorPrefab;
        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            // add player at correct spawn position
            Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
            GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
            NetworkServer.AddPlayerForConnection(conn, player);


            
            // spawn ball if two players
            if (numPlayers == 2)
            {
                int doorOpen_1;
                int doorOpen_2;
                int doorOpen_3;

                GameObject door0 = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Door"), Doors1[0].transform.position, Doors1[0].transform.rotation);
                GameObject door1 = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Door"), Doors1[1].transform.position, Doors1[1].transform.rotation);
                GameObject door2 = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Door"), Doors1[2].transform.position, Doors1[2].transform.rotation);

                GameObject door3 = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Door"), Doors2[0].transform.position, Doors2[0].transform.rotation);
                GameObject door4 = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Door"), Doors2[1].transform.position, Doors2[1].transform.rotation);
                GameObject door5 = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Door"), Doors2[2].transform.position, Doors2[2].transform.rotation);

                GameObject door6 = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Door"), Doors3[0].transform.position, Doors3[0].transform.rotation);
                GameObject door7 = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Door"), Doors3[1].transform.position, Doors3[1].transform.rotation);
                GameObject door8 = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Door"), Doors3[2].transform.position, Doors3[2].transform.rotation);

                System.Random rand = new System.Random();

                GameObject[] line_1 = { door0, door1, door2 };
                GameObject[] line_2 = { door3, door4, door5 };
                GameObject[] line_3 = { door6, door7, door8 };


                doorOpen_1 = rand.Next(line_1.Length);
                doorOpen_2 = rand.Next(line_2.Length);
                doorOpen_3 = rand.Next(line_3.Length);


                line_1[doorOpen_1].GetComponent<BoxCollider2D>().isTrigger = true;
                line_2[doorOpen_2].GetComponent<BoxCollider2D>().isTrigger = true;
                line_3[doorOpen_3].GetComponent<BoxCollider2D>().isTrigger = true;

                NetworkServer.Spawn(door0);
                NetworkServer.Spawn(door1);
                NetworkServer.Spawn(door2);

                NetworkServer.Spawn(door3);
                NetworkServer.Spawn(door4);
                NetworkServer.Spawn(door5);

                NetworkServer.Spawn(door6);
                NetworkServer.Spawn(door7);
                NetworkServer.Spawn(door8);

            }
        }

        /*
        public override void OnServerDisconnect(NetworkConnection conn)
        {
            // destroy ball
            if (door != null)
                NetworkServer.Destroy(door);

            // call base functionality (actually destroys the player)
            base.OnServerDisconnect(conn);
        }*/
    }
}
