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
    void Start()
    {
        difficulty = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().diff;
        CalculateAndAdd(difficulty);
        Print();
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

}
