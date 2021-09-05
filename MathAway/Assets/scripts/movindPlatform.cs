using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movindPlatform : MonoBehaviour
{
    public float pointA;
    public float pointB;
    public float pointC;
    public float pointD;

    public Vector2 pos1;
    public Vector2 pos2;
    public float speed = 0.2f;

    void Start()
    {
        //float temp1 = Random.Range(pointC, pointD);
        pos1 = new Vector2(pointA, transform.position.y);
        pos2 = new Vector2(pointB, transform.position.y);
    }


    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1f));
    }
}
