using UnityEngine;
using System.Collections;

public class ParticuleLayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Characters";
    }
	
	
}
