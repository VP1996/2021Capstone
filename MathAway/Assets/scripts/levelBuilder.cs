using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelBuilder : MonoBehaviour
{
    public GameObject plat1;
    public GameObject plat2;
    public GameObject plat3;



    public float pointA;
    public float pointB;
    public float pointC;
    public float pointD;
    public int numberOfPlanks1;
    public int numberOfPlanks2;
    public int numberOfPlanks3;

    public Vector3 pos1, pos2, pos3;
    //public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {


        for (int i = 1; i <= numberOfPlanks1; i++)
        {
            float temp1 = Random.Range(pointC, pointD);
            float temp2 = Random.Range(pointA, pointB);
            pos1 = new Vector3(temp2, temp1, 0);
            Instantiate(plat1, pos1, transform.rotation, transform);
        }
        for (int i = 1; i <= numberOfPlanks2; i++)
        {
            float temp1 = Random.Range(pointC, pointD);
            pos1 = new Vector3(Random.Range(pointA, pointB), temp1, 0);
            Instantiate(plat2, pos1, transform.rotation, transform);
        }
        for (int i = 1; i <= numberOfPlanks3; i++)
        {
            float temp1 = Random.Range(pointC, pointD);
            pos1 = new Vector3(Random.Range(pointA, pointB), temp1, 0);
            Instantiate(plat3, pos1, transform.rotation, transform);
        }
    }


    
}

