using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Stat{

    [SerializeField]
    public BarScript bar;

    [SerializeField]
    private float maxVal;

    [SerializeField]
    private float currentVal;

    [SerializeField]
    private float regen;

    public float CurrentVal
    {
        get
        {
            return currentVal;
        }

        set
        {
            currentVal = value;
            bar.Value = CurrentVal;
        }
    }

    public float MaxVal
    {
        get
        {
            return maxVal1;
        }

        set
        {
            maxVal1 = value;
            bar.MaxValue = maxVal;
        }
    }

    public float Regen
    {
        get
        {
            return regen;
        }

        set
        {
            regen = value;
        }
    }

    private float maxVal1;


    public void Init()
    {
        this.MaxVal = maxVal;
    }
}
