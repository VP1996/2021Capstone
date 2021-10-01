using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour
{
    public int count = 1;
    public int difficulty;
    Scene scene;

    public void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    
    {
        GameObject collisionGameObject = collision.gameObject;

        if (collisionGameObject.tag == "Player")
        {
            Die(collisionGameObject);
        }
    }
    public void Die(GameObject player)
    {
        difficulty = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().diff;
        if (scene.name == "Level1")
        {
            string name = "Start position (" + difficulty + ")(Clone)";
            FindObjectOfType<AudioManager>().Play("Death");
            player.transform.position = GameObject.Find(name).transform.position;
            GameObject.Find("Results").gameObject.GetComponent<Results>().AddDeathsLevel1(count);
        }
        else
        {
            string name = "Start position (" + difficulty + ")";
            FindObjectOfType<AudioManager>().Play("Death");
            player.transform.position = GameObject.Find(name).transform.position;
            GameObject.Find("Results").gameObject.GetComponent<Results>().AddDeathsLevel2(count);
        }
    }
}
