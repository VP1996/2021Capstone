using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movindPlatform : MonoBehaviour
{
    float dirX;
    float speed = 3f;

    bool movingRight = true;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 4f)
        {
            movingRight = false;
        }else if(transform.position.x < -4f)
        {
            movingRight = true;
        }

        if (movingRight) 
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}
