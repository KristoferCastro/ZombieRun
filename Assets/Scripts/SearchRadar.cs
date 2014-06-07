using UnityEngine;
using System.Collections;

/// <summary>
/// This class is responsible for detecting whether the player can be 
/// seen in the Zombies radar.
/// </summary>
public class SearchRadar : MonoBehaviour {

	bool foundPlayer;
	
	// Use this for initialization
	void Start () {
		foundPlayer = false;
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == GameObjectIDS.PLAYER){
			foundPlayer = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.name == GameObjectIDS.PLAYER){
			foundPlayer = false;
		}
	}
	
	public bool FoundPlayer {
		get {
			return foundPlayer;
		}
	}
}
