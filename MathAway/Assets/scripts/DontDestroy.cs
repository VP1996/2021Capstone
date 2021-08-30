using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DontDestroy : MonoBehaviour
{
    private GameObject[] canvas;
    private GameObject[] Event;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        Event = GameObject.FindGameObjectsWithTag("eventSys");
        if (Event.Length > 1)
        {
            Destroy(Event[1]);
        }
        canvas = GameObject.FindGameObjectsWithTag("UI");
        if (canvas.Length > 1)
        {
            Destroy(canvas[1]);
        }
    }
}
