using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWork : MonoBehaviour
{
    public GameObject platform;
    public int setDiff;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            platform.SetActive(false);
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            player.GetComponent<difficulty>().SetValues(setDiff);
        }
    }
}
