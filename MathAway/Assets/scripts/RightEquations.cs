using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RightEquations : MonoBehaviour
{
    public GameObject text;
    private List<string> equationsR = new List<string>();
    int difficulty;

    float timer;
    float WaitTime;
    bool startTimer;
    bool neverHit = true;
    public void Start()
    {
        difficulty = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().diff;
        CalculateAndAdd();
        Print();
        WaitTime = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().GetWAittime();
        timer = WaitTime;
    }
    public void Update()
    {
        if (startTimer==true) {
            timer -= Time.deltaTime;
            text.GetComponent<TextMesh>().text = "Right! Falling in " + Mathf.Round(timer).ToString();
            if (timer <=0)
            {
                startTimer = false;
                timer = difficulty;
            }
        }
    }
    void CalculateAndAdd()
    {
        int randint = Random.Range(100, 500);
        for (int X = 1; X <= randint; X++)
            {
                for(int y = 1;y<= randint; y++)
            {
                int z = X + y;
                string msg = X + " + " + y + " = " + z;
                equationsR.Add(msg);
            }    
           }
    }
    void Print()
    {
        int rand = Random.Range(0, equationsR.Count);
        text.GetComponent<TextMesh>().text = equationsR[rand];
        
    }
    public void UpdateFallTime()
    {
        WaitTime = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().GetWAittime();
    }

    public void Timer()
    {
        UpdateFallTime();
        startTimer = true;
        FindObjectOfType<AudioManager>().Play("Right");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && neverHit == true)
        {
            neverHit = false;
            Timer();
        }
    }
}


