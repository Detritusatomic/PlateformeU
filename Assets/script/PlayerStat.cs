using UnityEngine;
using System.Collections;

public class PlayerStat : MonoBehaviour {

    [SerializeField]
    public Stat mana;
    public Stat health;
    private float regenMana = 0;
    private float regenHealth = 0;

    // Use this for initialization
    private void Awake()
    {
        mana.Init();
        health.Init();
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (0 >= health.CurrentVal) respawn();

        if (Time.time > regenMana)
        {
            regenMana = Time.time + 1 / mana.Regen;
            mana.CurrentVal += 1;
            if (mana.CurrentVal > mana.MaxVal) mana.CurrentVal = mana.MaxVal;

        }

        if (Time.time > regenHealth)
        {
            regenHealth = Time.time + 1 / health.Regen;
            health.CurrentVal += 1;
            if (health.CurrentVal > health.MaxVal) health.CurrentVal = health.MaxVal;

        }
    }

    void respawn()
    {
        GameObject spawn = GameObject.Find("spawn");
        this.transform.position = spawn.transform.position;
        health.CurrentVal = health.MaxVal;
    }
}
