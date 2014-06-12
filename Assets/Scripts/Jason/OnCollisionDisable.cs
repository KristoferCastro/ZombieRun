using UnityEngine;
using System.Collections;

public class OnCollisionDisable : MonoBehaviour {
	
	public GameObject spawners;
	public string tag = "Player";

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == tag){
			spawners.SetActive(false);
		}
	}
}
