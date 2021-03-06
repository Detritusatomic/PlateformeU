﻿using UnityEngine;
using System.Collections;

public class moveBullet : MonoBehaviour {

    public int moveSpeed = 230;
    public int damage;
    public int hitLifeTime=2;
    public Transform hitPrefab;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime*moveSpeed);
        Destroy(gameObject, 2);
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != transform.gameObject.tag) {
            Transform impact = transform.FindChild("fireImpact");
            Quaternion rot = new Quaternion();
            Transform clone = Instantiate(hitPrefab, impact.position, transform.rotation) as Transform;
            Destroy(clone.gameObject, hitLifeTime);
            Destroy(gameObject);

            if (col.gameObject.tag == "Player")
            {
                PlayerStat stat = col.gameObject.GetComponent<PlayerStat>();
                stat.health.CurrentVal -= damage;
            }
            else if (col.gameObject.tag == "Enemy")
            {
                Destroy(col.gameObject);
            }
        }
    }
}
