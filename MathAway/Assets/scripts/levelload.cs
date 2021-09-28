using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;




public class levelload : MonoBehaviour
{
    private Text pickUpText;
    public GameObject text;

    public int ilevelToLoad;
    public bool repeat;
    public bool doorUnlocked;

    private void Awake()
    {
        pickUpText = GameObject.Find("PickupUI").gameObject.GetComponent<Text>();
    }
    public void Start()
    {
        pickUpText.gameObject.SetActive(false);
        doorUnlocked = false;
    }
    private void Update()
    {
        if (repeat && Input.GetKeyDown(KeyCode.E))
        {
            LoadScene();
        }
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            pickUpText.gameObject.SetActive(true);
            repeat = true;            
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUpText.gameObject.SetActive(false);
            repeat = false;
        }
    }

    void LoadScene()
    {
        if (ilevelToLoad == 2)
        {
            float time = GameObject.Find("Main Camera").gameObject.GetComponent<Stopwatch>().timeStart;
            GameObject.Find("Main Camera").gameObject.GetComponent<Stopwatch>().resettimer(0);
            GameObject.Find("Results").gameObject.GetComponent<Results>().setTimeLevel1(time);
            SceneManager.LoadScene(ilevelToLoad);
        }
        if (ilevelToLoad == 3)
        {
            if (doorUnlocked == true)
            {
                float time = GameObject.Find("Main Camera").gameObject.GetComponent<Stopwatch>().timeStart;
                GameObject.Find("Results").gameObject.GetComponent<Results>().setTimeLevel2(time);
                SceneManager.LoadScene(ilevelToLoad);
            }
            else
            {
                text.GetComponent<TextMesh>().text = "Need to open the right crate!";
                FindObjectOfType<AudioManager>().Play("Wrong");
            }

        }
    }

}