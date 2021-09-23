using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelBuilder : MonoBehaviour
{
    public List<GameObject> planks = new List<GameObject>();
    public float pointA;
    public float pointB;
    public float pointC;
    public float pointD;
    public int repeatV, repeatH;
    public float WaitTime;
    int repeat = 0;
    private IEnumerator coroutine;

    private List<Vector3> pos = new List<Vector3>();

    private void Start()
    {
        for (int i = 0; i < repeatV; i++)
            {
                int temp1 = (int)(pointC + 2 * i);

                for (int x = 0; x < repeatH; x++)
                {
                    int temp2 = (int)(pointA + 5 * x);
                    pos.Add(new Vector3(temp2, temp1, 0));
                }
            }
            coroutine = WaitAndBuild(WaitTime);
            StartCoroutine(coroutine);
            repeat = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GroundCheck")
        {
            Debug.Log("bump");
        }
    }


    private IEnumerator WaitAndBuild(float waitTime)
    {
        while (true)
        {
            Instantiate(planks[Random.Range(0, planks.Count)], pos[Random.Range(0, pos.Count)], transform.rotation, transform);
            yield return new WaitForSeconds(waitTime);
        }
    }




}

