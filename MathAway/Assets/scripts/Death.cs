using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour
{
    public int count = 0;
    public int currentscene;
    public int difficulty;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.name == "Player")
        {
            difficulty = collisionGameObject.GetComponent<difficulty>().diff;
            string name = "Start position (" + difficulty + ")";
            collisionGameObject.transform.position = GameObject.Find(name).transform.position;

            count++;
        }
    }
}
