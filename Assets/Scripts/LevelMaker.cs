using UnityEngine;
using System.Collections;

/// <summary>
/// This class is responsible for filling up the level with
/// static objects or "world" items.  For example, cars on the road
/// </summary>
public class LevelMaker : MonoBehaviour {

	public GameObject bus;
	public GameObject[] vehicles;
	public GameObject spawnArea;
	
	
	float minX;
	float maxX;
	float minY;
	float maxY;
	
	
	readonly int MAX_NUMBER_BUS = 10;
	int numberOfBus = 0;
	
	// Use this for initialization
	void Start () {
		BoxCollider2D spawnBox = spawnArea.GetComponent<BoxCollider2D>();
		minX = spawnArea.transform.position.x - spawnBox.size.x/2;
		maxX = minX + spawnBox.size.x;
		minY = spawnArea.transform.position.y - spawnBox.size.y/2;
		maxY = minY + spawnBox.size.y;
		while (numberOfBus < MAX_NUMBER_BUS){
			GameObject clone = (GameObject) Instantiate(vehicles[Random.Range (0, vehicles.Length-1)], RandomBusPosition(), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
			clone.transform.parent = GameObject.Find(GameObjectIDS.LEVEL_MANAGER).transform;
			// Make sure we are not putting the bus on top of another bus
			do{
				clone.transform.position = RandomBusPosition ();
			} while (AlreadyABusThere(clone));

			numberOfBus++;
		}
	}

	bool AlreadyABusThere(GameObject clone){
		float accuracy = 5; // size of circle
		return Physics.OverlapSphere (bus.transform.position, accuracy).Length > 0;
	}
	
	Vector3 RandomBusPosition(){
		return new Vector3(
			Random.Range(minX, maxX),
			Random.Range(minY, maxY));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
