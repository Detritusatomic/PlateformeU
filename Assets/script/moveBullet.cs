using UnityEngine;
using System.Collections;

public class moveBullet : MonoBehaviour {

    public int moveSpeed = 230;
    public Transform hitPrefab;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime*moveSpeed);
        Destroy(gameObject, 2);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Transform impact = transform.FindChild("fireImpact");
        Transform clone = Instantiate(hitPrefab, impact.position,transform.rotation) as Transform;
        Destroy(clone.gameObject,1);
        Destroy(gameObject);
    }
}
