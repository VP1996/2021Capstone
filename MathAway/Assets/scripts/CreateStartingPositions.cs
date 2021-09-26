using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStartingPositions : MonoBehaviour
{
    public Vector2 startingPosition;
    public GameObject StartPosition;
    private int limit;
    public int moveIncrement;
    private Vector2 pos;

    private void Awake()
    {
        transform.position = startingPosition;
        limit = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().level2Limit;
        for(int y = 0; y < limit; y++)
        {
            for (int x = 0; x < limit; x++)
            {
                pos = new Vector2(transform.position.x + moveIncrement*x, transform.position.y - moveIncrement * y);
                if (y == 0) {
                    GameObject temp = Instantiate(StartPosition, pos, Quaternion.identity, GameObject.Find("Starting Positions").gameObject.transform);
                    temp.gameObject.tag = "StartPosition";
                }
                else
                {
                    GameObject temp = Instantiate(StartPosition, pos, Quaternion.identity, GameObject.Find("Starting Positions").gameObject.transform);
                }

            }
        }
    }
}
