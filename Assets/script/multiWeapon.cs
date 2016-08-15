using UnityEngine;
using System.Collections;

public class multiWeapon : MonoBehaviour {

    ArrayList armes = new ArrayList();
    private int armeCourant;

    void Start () {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform tmp = transform.GetChild(i);
            if (tmp.tag == "Weapon")
            {
                tmp.gameObject.SetActive(false);
                armes.Add(tmp);
            }
        }
        Transform t = (Transform)armes[0];
        t.gameObject.SetActive(true);
        armeCourant = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            Transform t = (Transform)armes[armeCourant];
            t.gameObject.SetActive(false);
            armeCourant = (armeCourant + 1) % armes.Count;
            t = (Transform)armes[armeCourant];
            t.gameObject.SetActive(true);

        }
    }
}
