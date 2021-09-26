using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Stopwatch : MonoBehaviour
{
    public float timeStart = 0;
    private Text textBox;

    void Start()
    {
        textBox = GameObject.Find("Stopwatch").gameObject.GetComponent<Text>();
        textBox.text = timeStart.ToString("F2");
    }

    void Update()
    {
        
            timeStart += Time.deltaTime;
            textBox.text = timeStart.ToString("F2");
        
    }
    public void resettimer(float t)
    {
        timeStart = t;
    }
    
}
