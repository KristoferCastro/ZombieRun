using UnityEngine;
using System.Collections;

/// <summary>
/// This class is responsible for spawning/firing off obstacles 
/// </summary>
public class ObstacleManager : MonoBehaviour {

	public GameObject bus;

	// keep track of all our clones so we can destroy it later
	ArrayList clones;
	
	// Use this for initialization
	void Start () {
		clones = new ArrayList();
		bus.rigidbody2D.velocity = new Vector2(-0.2f, 0f);
		InvokeRepeating ("LaunchBus", 1f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		DestroyBusClonesWhenNotNeeded();
	}
	
	void LaunchBus(){
		Vector2 randomPosition = new Vector2(Random.Range(transform.position.x, (-1f)*transform.position.x), transform.position.y);
		clones.Add(Instantiate (bus, randomPosition, transform.rotation));
	}
	
	void DestroyBusClonesWhenNotNeeded(){
		foreach (GameObject clone in clones){
			if (clone && clone.transform.position.y < Camera.main.transform.position.y - 2f*Camera.main.orthographicSize){
				DestroyImmediate (clone);
			}
		}
	}
}
