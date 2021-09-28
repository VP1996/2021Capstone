using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallimgPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 currentPosition;
    float WaitTime;
    public GameObject plank;
    private IEnumerator coroutine;
    private bool col;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPosition = gameObject.transform.position;
        WaitTime = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().waitTime;
        coroutine = WaitAndBuild(WaitTime);
        col = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        
        if (collisionGameObject.name == "Player" && col==false)
        {
            col = true;
            StartCoroutine(coroutine);
        }
    }


    private IEnumerator WaitAndBuild(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        rb.isKinematic = false;
        yield return new WaitForSeconds(2);
        rb.isKinematic = true;
        GameObject plankNew = Instantiate(plank, currentPosition, Quaternion.identity, GameObject.Find("level builder").gameObject.transform);
        Destroy(gameObject);


        

    }

}
