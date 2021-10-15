using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWork : MonoBehaviour
{
    public GameObject platform;


   


    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            platform.SetActive(false);
            GameObject.Find("Dificulty").GetComponent<difficulty>().SetValues(0, 20, 5);
        }
    }
}
