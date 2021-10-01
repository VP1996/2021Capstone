using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Results : MonoBehaviour
{
    public int GotWrongOnlevel1, GotWrongOnlevel2;
    public int DiedOnlevel1, DiedOnlevel2;
    public static Results instance;
    public float tookTimeLevel1, tookTimeLevel2;
    public int difficulty;





    public void Start()
    {
        if (instance == null)
            instance = this;
        else
        { Destroy(gameObject); };
        DontDestroyOnLoad(gameObject);
        difficulty = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().diff;
    }

    public void AddWrongAnswersLevel1(int wrong)
    {
        GotWrongOnlevel1 += wrong;
    }
    public void AddDeathsLevel1(int died)
    {
        DiedOnlevel1 += died;
    }
    public void AddWrongAnswersLevel2(int wrong)
    {
        GotWrongOnlevel2 += wrong;
    }
    public void AddDeathsLevel2(int died)
    {
        DiedOnlevel2 += died;
    }
    public void setTimeLevel1(float time)
    {
        tookTimeLevel1 = time;
    }
    public void setTimeLevel2(float time)
    {
        tookTimeLevel2 = time;
    }
    public void ResetResults(int d1, int d2, int w1, int w2, float t1, float t2)
    {
        //FindObjectOfType<userInsert>().AddResults(Try.ToString(), difficulty.ToString(), DiedOnlevel1.ToString(),tookTimeLevel1.ToString(), GotWrongOnlevel1.ToString(), DiedOnlevel2.ToString(),tookTimeLevel2.ToString(), GotWrongOnlevel2.ToString());
        System.DateTime theTime = System.DateTime.Now;
        Debug.Log(theTime + "; difficulty was =  "+ difficulty.ToString() + "; DiedOnlevel1 = " + 
            DiedOnlevel1.ToString() + "; tookTimeLevel1 = " + 
            tookTimeLevel1.ToString() + "; GotWrongOnlevel1 = " + 
            GotWrongOnlevel1.ToString() + "; DiedOnlevel2 = " + 
            DiedOnlevel2.ToString() + "; tookTimeLevel2 = " + 
            tookTimeLevel2.ToString() + "; GotWrongOnlevel2 = " + 
            GotWrongOnlevel2.ToString());
        GotWrongOnlevel1 = w1;
        GotWrongOnlevel2 = w2;
        DiedOnlevel1 = d1;
        DiedOnlevel2 = d2;
        tookTimeLevel1 = t1;
        tookTimeLevel2 = t2;
    }
}
