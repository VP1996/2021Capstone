using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Goal : MonoBehaviour
{
    public GameObject effect;
    public GameObject text;
    public Vector2 fireworks;
    public bool goal;
    float time;
    private IEnumerator coroutine;
    private IEnumerator returnToMain;


    void Start()
    {
        coroutine = WaitAndPrint(0.5f);
        returnToMain = WaitAndReturn(10f);
        goal = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player") && goal==false)
        {
            goal = true;
            text.GetComponent<TextMesh>().text = "Congratulations!";
            StartCoroutine(coroutine);
            StartCoroutine(returnToMain);
            FindObjectOfType<AudioManager>().Play("Goal");
            FindObjectOfType<AudioManager>().Stop("Background");
        }
    }
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            float Rand = Random.Range(-5, 5);
            Vector2 pos = new Vector2(fireworks.x + Rand, fireworks.y);
            Instantiate(effect, pos, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            
        }
    }
    private IEnumerator WaitAndReturn(float waitTime)
    {
        
            yield return new WaitForSeconds(waitTime);
        GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().SetValues(0, 0, 0, 0);
        GameObject.Find("Results").gameObject.GetComponent<Results>().ResetResults(0, 0, 0, 0, 0, 0);
        GameObject.Find("Main Camera").gameObject.GetComponent<Stopwatch>().resettimer(0);
        FindObjectOfType<AudioManager>().Stop("Goal");
        FindObjectOfType<AudioManager>().Play("Background");
        SceneManager.LoadScene(0);


    }
}
