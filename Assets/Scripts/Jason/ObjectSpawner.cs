using UnityEngine;
using System.Collections;

/// <summary>
/// This class is responsible for spawning/firing off obstacles 
/// </summary>
public class ObjectSpawner : MonoBehaviour {
	
	public GameObject obj;
	public GameObject player;
	public float spawnerLocationX = 0;
	public float spawnerLocationY = 0;
	public float spawnerSize = 2;
	public bool TopOnly = true;
	public GameObject spawnerStart;
	public GameObject spawnerEnd;
	
	// variables that make the spawning work
	// They spawn in the edges of a imaginary spawn circle
	// that is some units ahead of the player to give the 
	// illusion they are coming.
	float spawnRadius; // this will be set to the colliders radius
	float angleMin = 0;
	float angleMax = 180;
	float randomAngle;
	float x;
	float y;

	
	
	// Use this for initialization
	void Start () {
		if (TopOnly) {
			InvokeRepeating ("SpawnObjectTopOnly", 1f, 2.5f);
		} else InvokeRepeating ("SpawnObjectAroundCircle", 1f, 2.5f);				
		spawnRadius = gameObject.GetComponent<CircleCollider2D>().radius;
		transform.position = new Vector3(spawnerLocationX, player.transform.position.y + spawnRadius/2, 0);
		spawnerStart.transform.position = new Vector3(spawnerStart.transform.position.x + spawnerSize, spawnerStart.transform.position.y, 0);
	}
	
	// Update is called once per frame
	void Update () {
		AdjustPosition();
		//DestroyZombiesWhenNotNeeded();
	}
	
	void AdjustPosition(){
		transform.position = new Vector3(transform.position.x, player.transform.position.y + spawnRadius/2, 0);
	}
	
	void OnTriggerExit2D(Collider2D other){
		if (other.name == obj.name){
			DestroyObject (other.gameObject);
		}
	}
	
	void SpawnObjectAroundCircle(){
		randomAngle = Random.Range(angleMin, angleMax)*Mathf.Deg2Rad;
		x = spawnRadius * Mathf.Cos (randomAngle);
		y = spawnRadius * Mathf.Sin (randomAngle);
		Instantiate (obj, new Vector3(x, y, 0) + transform.position, Quaternion.identity);
	}

	void SpawnObjectTopOnly(){
		Instantiate(obj,new Vector3(Random.Range(spawnerStart.transform.position.x, spawnerEnd.transform.position.x),
		                       		transform.position.y, 0), Quaternion.identity);
	}
	
	/// <summary>
	/// Destroies the zombies when not needed--when they are not in
	/// the screen anymore.
	/// </summary>
	void DestroyObject(GameObject obj){
		Destroy(obj);
	}
}
