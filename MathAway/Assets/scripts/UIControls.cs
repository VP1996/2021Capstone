using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIControls : MonoBehaviour
{
    public float b;
    private Text textBox;
    void Start()
    {
        textBox = GameObject.Find("Bullets").gameObject.GetComponent<Text>();
        b = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerControls>().bullets;
        textBox.text = b.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        b = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerControls>().bullets;
        textBox.text = b.ToString();
    }
}
