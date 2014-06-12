using UnityEngine;
using System.Collections;

public class Progress : MonoBehaviour {

	public Transform startPoint;
	public Transform endPoint;
	public Transform player;
	public Transform zombieHorde;
	
	public float progress = 0f;
	
	public float zombieHordeProgress = 0f;
	float totalDistance;
	
	// Use this for initialization
	void Start () {
		InitializeIfNotHookedUp();
		Setup();
	}
	
	void Setup(){
		totalDistance = endPoint.position.y - startPoint.position.y;
	}
	
	void InitializeIfNotHookedUp(){
		if (startPoint == null)
			startPoint = GameObject.Find(GameObjectIDS.STARTING_POINT).transform;
		if (endPoint == null)
			endPoint = GameObject.Find(GameObjectIDS.END_POINT).transform;
		if (player == null)
			player = GameObject.Find(GameObjectIDS.PLAYER).transform;
	}
	// Update is called once per frame
	void Update () {
		calculateProgress();
		calculateZombieProgress();
		//Debug.Log ("Player progress: " + progress + "%");
	}
	
	void calculateProgress(){
		float distanceFromStart = player.position.y - startPoint.position.y;
		progress = distanceFromStart/totalDistance * 100; 
	}
	
	void calculateZombieProgress(){
		float distanceFromStart = zombieHorde.position.y - startPoint.position.y;
		zombieHordeProgress = distanceFromStart/totalDistance*100;
	}
	
	
}
