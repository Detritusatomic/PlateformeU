using UnityEngine;
using System.Collections;

public class bombeAnimation : MonoBehaviour {

    public Transform bombe;
    public float firerate = 0;
    private float timeToFire = 0;

    // Update is called once per frame
    void Update () {

        if (Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / firerate;
            Transform target = transform.FindChild("explosion");
            Transform tmp = Instantiate(bombe, target.position, target.rotation) as Transform;
            Destroy(tmp.gameObject, 4);
        }
        
    }
}
