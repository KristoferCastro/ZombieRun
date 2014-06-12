using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {
	public float seconds = 10;
	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, seconds);
	}
}
