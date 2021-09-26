using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelloadOnHit : MonoBehaviour
{
    public int ilevelToLoad;
    public bool repeat = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player" && repeat == false)
        {
            repeat = true;
            LoadScene();
            
        }
    }

    void LoadScene()
    {
        if (ilevelToLoad == 1)
        {
            SceneManager.LoadScene(ilevelToLoad);
        }
        if (ilevelToLoad == 2)
        {
            float time = GameObject.Find("Main Camera").gameObject.GetComponent<Stopwatch>().timeStart;
            GameObject.Find("Main Camera").gameObject.GetComponent<Stopwatch>().resettimer(0);
            GameObject.Find("Results").gameObject.GetComponent<Results>().setTimeLevel1(time);
            SceneManager.LoadScene(ilevelToLoad);
        }
        if (ilevelToLoad == 3)
        {
            float time = GameObject.Find("Main Camera").gameObject.GetComponent<Stopwatch>().timeStart;
            GameObject.Find("Results").gameObject.GetComponent<Results>().setTimeLevel2(time);
            SceneManager.LoadScene(ilevelToLoad);
        }
    }

}