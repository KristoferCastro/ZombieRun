using UnityEngine;
using System.Collections;

public class SpeedPowerup : MonoBehaviour {

	public GameObject player;
	float maxSpeedIncrease = 0.35f;
	
	// Use this for initialization
	void Start () {
		DeleteAfter (7);
		
		// just in case I didn't hook up player in the UI
		if (player == null)
			player = GameObject.Find(GameObjectIDS.PLAYER);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == GameObjectIDS.PLAYER){
			DeleteAfter(0);
			player.GetComponent<PlayerController>().maxSpeed += maxSpeedIncrease;
		}
	}
	
	void DeleteAfter(float seconds){
		Destroy(this.gameObject, seconds);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
