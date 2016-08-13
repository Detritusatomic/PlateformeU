using UnityEngine;
using System.Collections;

public class gunRotation : MonoBehaviour {

    [SerializeField]public int rotationOffset = 90;
    protected bool paused=false;
    // Update is called once per frame
    void Update () {
        if (!paused)
        {
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;

            Vector3 difference = Camera.main.ScreenToWorldPoint(new Vector3(x, y, -Camera.main.transform.position.z)) - transform.position;
            difference.Normalize();
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
        }
	}

    void OnPauseGame()
    {
        paused = true;
    }

    void OnResumeGame()
    {
        paused = false;
    }


}
