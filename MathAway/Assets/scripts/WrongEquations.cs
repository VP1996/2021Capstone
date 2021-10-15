using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongEquations : MonoBehaviour
{
    public GameObject text;
    private List<string> equationsW = new List<string>();
    int difficulty;
    int count=1;
    bool neverHit = true;
    bool resetText = false;
    float timer = 2f;

    void Start()
    {
        difficulty = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().diff;
        CalculateAndAdd();
        Print();
    }
    private void Update()
    {
        if (resetText == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                resetText = false;
                timer = 2f;
                Print();
            }
        }
    }
    void CalculateAndAdd()
    {
       int randint = Random.Range(100, 500);
        for (int X = 1; X <= randint; X++)
        {
            for (int y = 1; y <= randint; y++)
            {
                int z = X + y+ Random.Range(5, 50); ;
                string msg = X + " + " + y + " = " + z;
                equationsW.Add(msg);
            }
        }


    }
    void Print()
    {
        int rand = Random.Range(0, equationsW.Count);
        text.GetComponent<TextMesh>().text = equationsW[rand];

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && neverHit == true)
        {
            neverHit = false;
            GameObject.Find("Results").gameObject.GetComponent<Results>().AddWrongAnswersLevel1(count);
        }
        text.GetComponent<TextMesh>().text = "Wrong !";
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && resetText == false)
        {
            resetText = true;
            
        }

    }

}
