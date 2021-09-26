using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWork : MonoBehaviour
{
    public GameObject platform;
    public int setDiff;
    public int setBonus;
    public float waitTime;
    public int level2Limit;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            platform.SetActive(false);
            GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().SetValues(setDiff, setBonus, waitTime, level2Limit);
            
        }
    }
}
