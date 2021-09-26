using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficulty : MonoBehaviour
{
    public int diff;
    public int bullets;
    public float waitTime;
    public int level2Limit;

    public static difficulty instance;

    void Start()
    {
        if (instance == null)
            instance = this;
        else
        { Destroy(gameObject); };
        DontDestroyOnLoad(gameObject);
    }

    public void SetValues(int dif,int bull, float wTime,int lim)
    {
        diff = dif;
        bullets = bull;
        waitTime = wTime;
        level2Limit = lim;
    }
}
