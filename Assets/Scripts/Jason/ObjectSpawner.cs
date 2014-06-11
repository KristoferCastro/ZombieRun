using UnityEngine;
using System.Collections;

/// <summary>
/// This class is responsible for spawning/firing off obstacles 
/// </summary>
public class ObjectSpawner : MonoBehaviour {
	
	public GameObject obj;
	public GameObject player;
	public float displacement;
	
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
	public GameObject horizontalSpawnerStart;
	public GameObject horizontalSpawnerEnd;
	
	
	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnObjectTopOnly", 1f, 2.5f);		
		spawnRadius = gameObject.GetComponent<CircleCollider2D>().radius + 10;
		transform.position = new Vector3(displacement, player.transform.position.y + spawnRadius/2, 0);

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
		Instantiate (obj, new Vector3(x, y, 0) + transform.position,
		             Quaternion.identity);
	}
	
	// Zombies only pop up from the top
	void SpawnObjectTopOnly(){
		Instantiate(obj, new Vector3( 
		                                Random.Range(horizontalSpawnerStart.transform.position.x, horizontalSpawnerEnd.transform.position.x),
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
