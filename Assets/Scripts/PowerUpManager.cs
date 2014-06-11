using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour {
	
	float interval = 2f; // interval to attempt to spawn powerup
	int chance = 35; // chance to spawn a powerup
	float offsetFromPlayer = 5f;
	
	public GameObject speedPowerup;
	public GameObject player;
	
	BoxCollider2D spawnBox;
	
	float minX;
	float maxX;
	float minY;
	float maxY;
	
	// Use this for initialization
	void Start () {
		spawnBox = GetComponent<BoxCollider2D>();
		CalculateSpawnboxPoints();
		// if player not hooked up in the unity interface
		if (player == null)
			player = GameObject.Find(GameObjectIDS.PLAYER);
		
		InvokeRepeating ("SpawnSpeedPowerup", 1f, interval);
		
	}
	
	// Update is called once per frame
	void Update () {
		MoveSpawner();
	}	
	
	// get the 4 points that make up the square that is the spawn box
	void CalculateSpawnboxPoints(){
		minX = transform.position.x - spawnBox.size.x/2;
		maxX = minX + spawnBox.size.x;
		minY = transform.position.y - spawnBox.size.y/2;
		maxY = minY + spawnBox.size.y;
	}
	
	// move the power up manager by some set offset from the player
	void MoveSpawner(){
		transform.position = new Vector3(transform.position.x, 
		                                 player.transform.position.y + offsetFromPlayer);
	}
	
	void SpawnSpeedPowerup(){
		int randomValue = Random.Range(0, 100);
		
		// unfortunately, no power up spawn!
		if (randomValue >= chance ) return;
		
		GameObject powerupClone = (GameObject) Instantiate (speedPowerup, RandomPowerupPosition(), Quaternion.identity);
		do{
			powerupClone.transform.position = RandomPowerupPosition();
		}while(ThereIsAObstacleThere(powerupClone));
	}
	
	bool ThereIsAObstacleThere(GameObject powerup){
		float accuracy = 0.64f; // size of circle
		return Physics.OverlapSphere (powerup.transform.position, accuracy).Length > 0;
	}
	
	Vector3 RandomPowerupPosition(){
		CalculateSpawnboxPoints();
		return new Vector3(Random.Range(minX,maxX), 
		                   Random.Range(minY, maxY),
		                   speedPowerup.transform.position.z);
	}
}