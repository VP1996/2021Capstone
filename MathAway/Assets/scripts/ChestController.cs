using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour
{

    private Text pickUpText;

    private bool pickUpAllowed;
    private bool AlreadyPicked;

    public int type;

    public GameObject text;
    private List<string> SolutionW = new List<string>();
    private string SolutionR;
    private string Equation;
    private string[] EquationType = new string[] { "Mult","Dev","SQRT"};
    int difficulty;

    // Use this for initialization
    private void Awake()
    {
        pickUpText = GameObject.Find("PickupUI").gameObject.GetComponent<Text>();

    }
    public void Start()
    {
        string temp = "No?";
        SolutionW.Add(temp);
        difficulty = GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().diff;
        pickUpText.gameObject.SetActive(false);
        CreateEquationsAndAnswers(difficulty,EquationType[Random.Range(0,EquationType.Length)]);
        Print(type);
    }

    // Update is called once per frame
    public void Update()
    {
     
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E)&& AlreadyPicked == false)
            PickUp();

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }
   

    public void PickUp()
    {
        //FindObjectOfType<AudioManager>().Play("ChestOpen");
        AlreadyPicked = true;
        if (type == 0)
        {
            text.GetComponent<TextMesh>().text = "Wrong";
            FindObjectOfType<AudioManager>().Play("Baam");
            FindObjectOfType<Death>().Die(GameObject.Find("Player"));
        }
        else if (type == 1)
        {
            text.GetComponent<TextMesh>().text = "Right";
            FindObjectOfType<AudioManager>().Play("Right");
            FindObjectOfType<levelload>().doorUnlocked = true;
        }

    }

    void CreateEquationsAndAnswers(int diff, string EType)
    {
        if (diff == 1)
        {
            float x = Random.Range(1, 11);
            float y = Random.Range(1, 11);
            float z = Random.Range(1, 11);
            float Find;

            if (EType.Equals("Mult"))
            {
                Find = (z * x) / y;
                Find.ToString("F2");
                SolutionR = Find + " ?";
                string msg = y + "* X" + " / " + x + " = " + z;
                Equation = msg;
                for (int i = -1; i <= 10; i++)
                {
                    float Wrong = Find + i;
                    string msgg = Wrong + "?";
                    SolutionW.Add(msgg);
                }
            }
            if (EType.Equals("SQRT"))
            {
                Find = (y * y) / x;
                Find.ToString("F2");
                SolutionR = Find + " ?";
                string msg = "Sqrt( " + x + " * X) = " + y;
                Equation = msg;
                for (int i = -1; i <= 10; i++)
                {
                    float Wrong = Find + i;
                    string msgg = Wrong + "?";
                    SolutionW.Add(msgg);
                }
            }
            if (EType.Equals("Dev"))
            {
                Find = (x / z) / y;
                Find.ToString("F2");
                SolutionR = Find + " ?";
                string msg = x + " / (" + y + " * X) = " + z;
                Equation = msg;
                for (int i = -1; i <= 10; i++)
                {
                    float Wrong = Find + i;
                    string msgg = Wrong + "?";
                    SolutionW.Add(msgg);
                }
            }
        }
        if (diff == 2)
        {
            float x = Random.Range(1, 22);
            float y = Random.Range(1, 22);
            float z = Random.Range(1, 22);
            float Find;

            if (EType.Equals("Mult"))
            {
                Find = (z * x) / y;
                Find.ToString("F2");
                SolutionR = Find + " ?";
                string msg = y + "* X" + " / " + x + " = " + z;
                Equation = msg;
                for (int i = -1; i <= 10; i++)
                {
                    float Wrong = Find + i;
                    string msgg = Wrong + "?";
                    SolutionW.Add(msgg);
                }
            }
            if (EType.Equals("SQRT"))
            {
                Find = (y * y) / x;
                Find.ToString("F2");
                SolutionR = Find + " ?";
                string msg = "Sqrt( " + x + " * X) = " + y;
                Equation = msg;
                for (int i = -1; i <= 10; i++)
                {
                    float Wrong = Find + i;
                    string msgg = Wrong + "?";
                    SolutionW.Add(msgg);
                }
            }
            if (EType.Equals("Dev"))
            {
                Find = (x / z) / y;
                Find.ToString("F2");
                SolutionR = Find + " ?";
                string msg = x + " / (" + y + " * X) = " + z;
                Equation = msg;
                for (int i = -1; i <= 10; i++)
                {
                    float Wrong = Find + i;
                    string msgg = Wrong + "?";
                    SolutionW.Add(msgg);
                }
            }
        }
        if (diff == 3)
        {
            float x = Random.Range(1, 33);
            float y = Random.Range(1, 33);
            float z = Random.Range(1, 33);
            float Find;

            if (EType.Equals("Mult"))
            {
                Find = (z * x) / y;
                Find.ToString("F2");
                SolutionR = Find + " ?";
                string msg = y + "* X" + " / " + x + " = " + z;
                Equation = msg;
                for (int i = -1; i <= 10; i++)
                {
                    float Wrong = Find + i;
                    string msgg = Wrong + "?";
                    SolutionW.Add(msgg);
                }
            }
            if (EType.Equals("SQRT"))
            {
                Find = (y * y) / x;
                Find.ToString("F2");
                SolutionR = Find + " ?";
                string msg = "Sqrt( " + x + " * X) = " + y;
                Equation = msg;
                for (int i = -1; i <= 10; i++)
                {
                    float Wrong = Find + i;
                    string msgg = Wrong + "?";
                    SolutionW.Add(msgg);
                }
            }
            if (EType.Equals("Dev"))
            {
                Find = (x / z) / y;
                Find.ToString("F2");
                SolutionR = Find + " ?";
                string msg = x + " / (" + y + " * X) = " + z;
                Equation = msg;
                for (int i = -1; i <= 10; i++)
                {
                    float Wrong = Find + i;
                    string msgg = Wrong + "?";
                    SolutionW.Add(msgg);
                }
            }
        }
    }

        void Print(int t)
        {
            if (t == 0)
            {
                if (SolutionW.Count > 1) SolutionW.Remove("No?");
                int rand = Random.Range(0, SolutionW.Count);
                if (SolutionW[rand].Equals(SolutionR)) rand++;
                text.GetComponent<TextMesh>().text = SolutionW[rand];

            }
            else if (t == 1)
            {
                text.GetComponent<TextMesh>().text = SolutionR;
                GameObject question = GameObject.Find("Question(Clone)");
                //Debug.Log(SolutionR + " " + Equation);
                question.GetComponent<TextMesh>().text = Equation;
            }
        }
 }


