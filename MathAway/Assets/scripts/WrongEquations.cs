using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongEquations : MonoBehaviour
{
    public GameObject text;
    private List<string> equationsW = new List<string>();
    int difficulty;
    int x = 1;
    int y = 1;
    int z = 1;
    int count=0;
    void Start()
    {
        difficulty = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().diff;
        CalculateAndAdd(difficulty);
        Print();
    }
    void CalculateAndAdd(int diff)
    {
        if (diff == 1)
        {
            for (int i = 1; i <= 10; i++)
            {
                x = x + i;
                y = y + x;
                z = x + y + Random.Range(100,600);
                string msg = x + " + " + y + " = " + z;
                equationsW.Add(msg);
            }
        }
        else if (diff == 2)
        {
            for (int i = 1; i <= 30; i++)
            {
                x = x + i;
                y = y + x;
                z = x + y + Random.Range(100, 600);
                string msg = x + " + " + y + " = " + z;
                equationsW.Add(msg);
            }
        }
        else if (diff == 3)
        {
            for (int i = 1; i <= 50; i++)
            {
                x = x + i;
                y = y + x;
                z = x + y + Random.Range(100, 600);
                string msg = x + " + " + y + " = " + z;
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
        text.GetComponent<TextMesh>().text = "Wrong !";
        count++;
        GameObject.Find("Results").gameObject.GetComponent<Results>().AddWrongAnswersLevel1(count);

    }

}
