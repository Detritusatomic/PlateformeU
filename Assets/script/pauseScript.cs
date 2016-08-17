using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pauseScript : MonoBehaviour {

    private bool showGUI = false;
    public Transform canvas;
    private Image weaponSprite;
    private Transform pause;
    private Text levelName;
    private Text weaponName;
    ArrayList armes = new ArrayList();

    void Start()
    {
        pause = canvas.FindChild("pause");
        weaponSprite = GameObject.Find("weaponSprite").GetComponent<Image>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform tmp = transform.GetChild(i);
            if (tmp.tag == "Weapon")
            {
                armes.Add(tmp);
            }
        }
        levelName = GameObject.Find("textLevel").GetComponent<Text>();
        weaponName = GameObject.Find("GunNAME").GetComponent<Text>();
    }

    void OnLevelWasLoaded()
    {
        pause = canvas.FindChild("pause");
        weaponSprite = GameObject.Find("weaponSprite").GetComponent<Image>();

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform tmp = transform.GetChild(i);
            if (tmp.tag == "Weapon")
            {
                armes.Add(tmp);
            }
        }
        levelName = GameObject.Find("textLevel").GetComponent<Text>();
        weaponName = GameObject.Find("GunNAME").GetComponent<Text>();
    }

    void Update()
    {
        for (int i = 0; i < armes.Count; i++)
        {
            Transform tmp = (Transform)armes[i];
            if (tmp.gameObject.activeSelf)
            {
                
                weaponSprite.sprite = tmp.gameObject.GetComponent<SpriteRenderer>().sprite;
                weaponName.text = tmp.gameObject.name;

            }
        }


        levelName.text = Application.loadedLevelName;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showGUI = !showGUI;
        }
        if (showGUI == true)
        {
            pause.gameObject.SetActive(true);
            Time.timeScale = 0;
            Object[] objects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objects)
            {
                go.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
            }
        }
        else
        {
            pause.gameObject.SetActive(false);
            Time.timeScale = 1;
            Object[] objects = FindObjectsOfType(typeof(GameObject));
            foreach (GameObject go in objects)
            {
                go.SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
    
}
