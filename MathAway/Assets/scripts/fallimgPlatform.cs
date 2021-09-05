using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallimgPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    //BoxCollider2D bc;
    Vector2 currentPosition;
    bool movingBack;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //bc = GetComponent<BoxCollider2D>();
        currentPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        
        if (collisionGameObject.name == "Player" && movingBack ==false)
        {
            Invoke("Falllatform", 1f);
        }
    }

    void Falllatform()
    {
        rb.isKinematic = false;
        //bc.isTrigger.Equals(true);
        Invoke("BackPlatform", 2f);
    }

    void BackPlatform()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        movingBack = true;

    }

    void Update()
    {
        if (movingBack == true)
        {
            transform.position = currentPosition;
        } 

        if (transform.position.y == currentPosition.y)
        {
            movingBack = false;

        }
    }
}
