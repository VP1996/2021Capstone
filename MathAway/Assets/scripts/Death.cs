using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour
{
    public int count = 0;
    public int difficulty;

    private void OnTriggerEnter2D(Collider2D collision)
    
    {
        GameObject collisionGameObject = collision.gameObject;
        Scene scene = SceneManager.GetActiveScene();

        if (collisionGameObject.name == "Player" || collisionGameObject.name == "Player(Clone)")
        {
            count++;
            difficulty = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().diff;
            if (scene.name == "Level1")
            {
                string name = "Start position (" + difficulty + ")(Clone)";
                FindObjectOfType<AudioManager>().Play("Death");
                collisionGameObject.transform.position = GameObject.Find(name).transform.position;
                GameObject.Find("Results").gameObject.GetComponent<Results>().AddDeathsLevel1(count);
            }
            else
            {
                string name = "Start position (" + difficulty + ")";
                FindObjectOfType<AudioManager>().Play("Death");
                collisionGameObject.transform.position = GameObject.Find(name).transform.position;
                GameObject.Find("Results").gameObject.GetComponent<Results>().AddDeathsLevel2(count);
            }
        }
    }
}
