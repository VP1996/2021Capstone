using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGeneration : MonoBehaviour
{

    public List<Transform> startingPositions = new List<Transform>();
    public GameObject[] rooms; // index 0 --> closed, index 1 --> LR, index 2 --> LRB, index 3 --> LRT, index 4 --> LRBT
    public GameObject Door;
    public GameObject Exit;
    public GameObject Player;
    public GameObject[] RespawnPoint;
    private int direction;
    private bool stopGeneration;
    private bool doneAlready = false;
    private int downCounter;
    private int limit;

    public float moveIncrement;
    private float borderLimit;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;

    public LayerMask whatIsRoom;


    private void Awake()
    {
        limit = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().level2Limit;
        borderLimit = -15 + moveIncrement * limit;
        foreach (GameObject position in GameObject.FindGameObjectsWithTag("StartPosition"))
        {
            startingPositions.Add(position.transform);
        }
        
        int randStartingPos = Random.Range(0, startingPositions.Count);
        transform.position = startingPositions[randStartingPos].position;
        Instantiate(rooms[1], transform.position, Quaternion.identity);
        Instantiate(Door, new Vector3(transform.position.x + 3, transform.position.y - 2.33f, 0), Quaternion.identity);
        foreach(GameObject x in RespawnPoint)
        {
           Instantiate(x, new Vector3(transform.position.x + 3, transform.position.y - 2.3f, 0), Quaternion.identity);

        }
        //Instantiate(Player, new Vector3(transform.position.x + 3, transform.position.y - 2.3f, 0), Quaternion.identity);

        direction = Random.Range(1, 5);
    }

    private void Update()
    {

        Move();
        
    }

    private void Move()
    {

        if (direction == 1 || direction == 2)
        { // Move right !

            if (transform.position.x < -borderLimit)
            {
                downCounter = 0;
                Vector2 pos = new Vector2(transform.position.x + moveIncrement, transform.position.y);
                transform.position = pos;

                int randRoom = Random.Range(1, 4);
                Instantiate(rooms[randRoom], transform.position, Quaternion.identity);

                // Makes sure the level generator doesn't move left !
                direction = Random.Range(1, 5);
                if (direction == 3)
                {
                    direction = 1;
                }
                else if (direction == 4)
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5;
            }
        }
        else if (direction == 3 || direction == 4)
        { // Move left !

            if (transform.position.x > 0)
            {
                downCounter = 0;
                Vector2 pos = new Vector2(transform.position.x - moveIncrement, transform.position.y);
                transform.position = pos;

                int randRoom = Random.Range(1, 2);
                Instantiate(rooms[randRoom], transform.position, Quaternion.identity);

                direction = Random.Range(3, 5);
            }
            else
            {
                direction = 5;
            }

        }
        else if (direction == 5)
        { // MoveDown
            downCounter++;
            if (transform.position.y > -borderLimit)
            {
                // Now I must replace the room BEFORE going down with a room that has a DOWN opening, so type 3 or 5
                Collider2D previousRoom = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);
                Debug.Log(previousRoom);
                if (previousRoom.GetComponent<Room>().roomType != 4 && previousRoom.GetComponent<Room>().roomType != 2)
                {

                    // My problem : if the level generation goes down TWICE in a row, there's a chance that the previous room is just 
                    // a LRB, meaning there's no TOP opening for the other room ! 

                    if (downCounter >= 2)
                    {
                        previousRoom.GetComponent<Room>().RoomDestruction();
                        Instantiate(rooms[4], transform.position, Quaternion.identity);
                    }
                    else
                    {
                        previousRoom.GetComponent<Room>().RoomDestruction();
                        int randRoomDownOpening = Random.Range(2, 5);
                        if (randRoomDownOpening == 3)
                        {
                            randRoomDownOpening = 2;
                        }
                        Instantiate(rooms[randRoomDownOpening], transform.position, Quaternion.identity);
                    }

                }



                Vector2 pos = new Vector2(transform.position.x, transform.position.y - moveIncrement);
                transform.position = pos;

                // Makes sure the room we drop into has a TOP opening !
                
                Instantiate(rooms[3], transform.position, Quaternion.identity);

                direction = Random.Range(1, 4);
            }
            else
            {
                stopGeneration = true;
                if (doneAlready == false)
                {
                    doneAlready = true;
                    Instantiate(Exit, new Vector3(transform.position.x + 3, transform.position.y - 2.33f, 0), Quaternion.identity);
                }
            }
            
        }
    }
}
