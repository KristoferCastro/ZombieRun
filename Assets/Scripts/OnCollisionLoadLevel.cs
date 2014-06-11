using UnityEngine;
using System.Collections;

public class OnCollisionLoadLevel : MonoBehaviour {

	public string tag = "Player";
	public string level = "Scene Name"; 
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == tag){
			// make it so it collides with player again!
			gameObject.collider2D.isTrigger = false;
			Debug.Log ("hitting the player son!");
			// do stuff when collided
			Application.LoadLevel(level);
		}
	}
}
