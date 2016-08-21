using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

    // Use this for initialization

    public float fillAmount;
    public Image content;

    public float MaxValue { get; set; }

    public float Value {
        set {
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }



    void Start() {

    }

    // Update is called once per frame
    void Update() {
        HandleBar();
    }

    private void HandleBar()
    {
        content.fillAmount = fillAmount;
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax){
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
