using UnityEngine;
using System.Collections;

public class MakeParticleViewable : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Renderer>().sortingLayerName = "foreground";
        gameObject.GetComponent<Renderer>().sortingOrder = 2;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
