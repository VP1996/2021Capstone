using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBorders : MonoBehaviour
{
    public Vector2 startingPositionX;
    public Vector2 startingPositionY;
    public GameObject StartPosition;
    private int limit;
    public int moveIncrement;
    private float borderLimit;
    private Vector2 pos1,pos2;

    private void Awake()
    {
        limit = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().level2Limit;
        borderLimit = limit * 10;
        for (float x = 0; x < borderLimit; x++)
        {
         pos1 = new Vector2(startingPositionX.x + moveIncrement*x, startingPositionX.y);
         pos2 = new Vector2(startingPositionX.x + moveIncrement * x, startingPositionX.y - borderLimit-1);
         Instantiate(StartPosition, pos1, Quaternion.identity,GameObject.Find("Borders").gameObject.transform);
         Instantiate(StartPosition, pos2, Quaternion.identity, GameObject.Find("Borders").gameObject.transform);
        }
        for (float y = 0; y < borderLimit+2; y++)
        {
            pos1 = new Vector2(startingPositionY.x, startingPositionY.y - moveIncrement * y);
            pos2 = new Vector2(startingPositionY.x+borderLimit+1, startingPositionY.y - moveIncrement * y);
            Instantiate(StartPosition, pos1, Quaternion.identity, GameObject.Find("Borders").gameObject.transform);
            Instantiate(StartPosition, pos2, Quaternion.identity, GameObject.Find("Borders").gameObject.transform);
        }
        

    }
}
