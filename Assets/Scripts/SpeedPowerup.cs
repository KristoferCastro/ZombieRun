using UnityEngine;
using System.Collections;

public class SpeedPowerup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DeleteAfter (5);
	}
	
	void DeleteAfter(float seconds){
		Destroy(this.gameObject, seconds);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
