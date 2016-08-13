using UnityEngine;
using System.Collections;

public class pauseScript : MonoBehaviour {

    private bool showGUI = false;
    public GameObject canvas;
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showGUI = !showGUI;
        }
        if (showGUI == true)
        {
            canvas.SetActive(true);
            Time.timeScale = 0;
            Object[] objects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objects)
            {
                go.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
            }
        }
        else
        {
            canvas.SetActive(false);
            Time.timeScale = 1;
            Object[] objects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objects)
            {
                go.SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
    
}
