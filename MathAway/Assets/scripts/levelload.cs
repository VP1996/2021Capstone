using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelload : MonoBehaviour
{
    public int ilevelToLoad;
    public string sLevelToLoad;

    public bool useIntegerToLoad = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name == "Player")
        {
            LoadScene();
        }
    }

    void LoadScene()    
    {
        if(useIntegerToLoad)
        {
            SceneManager.LoadScene(ilevelToLoad);
        }
        else
        {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }

}
