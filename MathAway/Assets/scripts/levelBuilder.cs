using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelBuilder : MonoBehaviour
{
    public GameObject Rplanks;
    public GameObject Wplanks;
    public List<GameObject> clones = new List<GameObject>();
    public float pointA;
    public float pointC;
    public int repeatV, repeatH;
    public float WaitTime;
    int repeat = 0;


    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && repeat == 0)
        {
            repeat = 1;
            buildLevel();
        }
    }


    
    private void buildLevel()
    {
        
        for (int i = 0; i < repeatV; i++)
        {
            int temp1 = (int)(pointC + 4 * i);
            int randomPositionH = Random.Range(0, repeatH);

            for (int x = 0; x < repeatH; x++)
            {
                int temp2 = (int)(pointA + 6 * x);
                if (randomPositionH == x)
                {
                    clones.Add(Instantiate(Rplanks, new Vector3(temp2, temp1, 0), transform.rotation, GameObject.Find("level builder").gameObject.transform));
                }
                else
                {
                    clones.Add(Instantiate(Wplanks, new Vector3(temp2, temp1, 0), transform.rotation, GameObject.Find("level builder").gameObject.transform));
                }

            }
        }
    }

    public void Reset()
    {
        clones.Clear();
        clones = new List<GameObject>();
        repeat = 0;
    }




}

