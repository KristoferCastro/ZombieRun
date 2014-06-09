using UnityEngine;
using System.Collections;

/// <summary>
/// This class is responsible for spawning/firing off obstacles 
/// </summary>
public class ZombieManager : MonoBehaviour {

	public GameObject zombie;
	public GameObject player;
	
	public GameObject bus;
	
	// keep track of all our clones so we can destroy it later
	ArrayList clones;
	
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
		clones = new ArrayList();
		InvokeRepeating ("SpawnZombieTopOnly", 1f, 2.5f);
		
		spawnRadius = gameObject.GetComponent<CircleCollider2D>().radius;
		transform.position = new Vector3(player.transform.position.x 
		                                 , player.transform.position.y + spawnRadius/2, 0);
		
		if (player == null)
			player = GameObject.Find(GameObjectIDS.PLAYER);
		if (horizontalSpawnerStart == null) 
			horizontalSpawnerStart = GameObject.Find(GameObjectIDS.HORIZONTAL_SPAWNER_START);
		if (horizontalSpawnerEnd == null)
			horizontalSpawnerEnd = GameObject.Find (GameObjectIDS.HORIZONTAL_SPAWNER_END);
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
		if ( other.name.Contains(GameObjectIDS.PUSHING_ZOMBIE)){
			DestroyZombie (other.gameObject);
		}
	}
	
	void SpawnZombieAroundCircle(){
		randomAngle = Random.Range(angleMin, angleMax)*Mathf.Deg2Rad;
		x = spawnRadius * Mathf.Cos (randomAngle);
		y = spawnRadius * Mathf.Sin (randomAngle);
		Instantiate (zombie, new Vector3(x, y, 0) + transform.position,
		Quaternion.identity);
	}
	
	// Zombies only pop up from the top
	void SpawnZombieTopOnly(){
		Instantiate(zombie, new Vector3( 
			Random.Range(horizontalSpawnerStart.transform.position.x, horizontalSpawnerEnd.transform.position.x),
			transform.position.y, 0), Quaternion.identity);
	}
	
	/// <summary>
	/// Destroies the zombies when not needed--when they are not in
	/// the screen anymore.
	/// </summary>
	void DestroyZombie(GameObject zombie){
		Destroy(zombie);
	}
}
