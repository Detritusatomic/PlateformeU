using UnityEngine;
using System.Collections;

public class PlayerStat : MonoBehaviour {

    [SerializeField]
    public Stat mana;
    private float regenMana = 0;

    // Use this for initialization
    private void Awake()
    {
        mana.Init();
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > regenMana)
        {
            regenMana = Time.time + 1 / mana.Regen;
            mana.CurrentVal += 1;
            if (mana.CurrentVal > mana.MaxVal) mana.CurrentVal = mana.MaxVal;

        }
    }
}
