using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class difficulty : MonoBehaviour
{
    public int diff;
    public int bullets;
    public static float waitTime;
    public int level2Limit;
    Scene scene;
    public static difficulty instance;

    void Start()
    {
        if (instance == null)
            instance = this;
        else
        { Destroy(gameObject); };
        DontDestroyOnLoad(gameObject);


        waitTime = PlayerPrefs.GetFloat("WaitTime",5);

        
    }
    public float GetWAittime()
    {
        return waitTime;
    }


    public void UpdateWaitTime(int add)
    {
        waitTime += add;
    }
    public void Updatelevel2Limit(int add)
    {
        level2Limit = add;
    }


    public void SetValues(int dif,int bull,int lim)
    {
        diff = dif;
        bullets = bull;
        level2Limit = lim;
    }
}
