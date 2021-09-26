using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public int health;
    public GameObject destEff;

    void Update()
    {
        if(health <= 0)
        {
            Instantiate(destEff, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
