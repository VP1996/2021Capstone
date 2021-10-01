using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RightEquations : MonoBehaviour
{
    public GameObject text;
    private List<string> equationsR = new List<string>();
    int difficulty;
    int x = 1;
    int y = 1;
    int z = 1;
    float timer;
    float WaitTime;
    bool startTimer;
    bool neverHit = true;
    public void Start()
    {
        difficulty = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().diff;
        CalculateAndAdd(difficulty);
        Print();
        WaitTime = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().waitTime;
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
    void CalculateAndAdd(int diff)
    {
        if(diff == 1)
        {
            for (int i = 1; i <= 10; i++)
            {
                x = x + i;
                y = y + x;
                z = x + y;
                string msg = x + " + " + y + " = " + z;
                equationsR.Add(msg);
            }
        }else if(diff == 2)
        {
            for (int i = 1; i <= 30; i++)
            {
                x = x + i;
                y = y + x;
                z = x + y;
                string msg = x + " + " + y + " = " + z;
                equationsR.Add(msg);
            }
        }
        else if (diff == 3)
        {
            for (int i = 1; i <= 50; i++)
            {
                x = x + i;
                y = y + x;
                z = x + y;
                string msg = x + " + " + y + " = " + z;
                equationsR.Add(msg);
            }
        }

    }
    void Print()
    {
        int rand = Random.Range(0, equationsR.Count);
        text.GetComponent<TextMesh>().text = equationsR[rand];
        
    }
    public void Timer()
    {
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


