using UnityEngine;
using System.Collections;

/// <summary>
/// This class is responsible for spawning/firing off obstacles 
/// </summary>
public class ObstacleManager : MonoBehaviour {

	public GameObject zombie;

	// keep track of all our clones so we can destroy it later
	ArrayList clones;
	
	// Use this for initialization
	void Start () {
		clones = new ArrayList();
		InvokeRepeating ("SpawnZombie", 1f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		DestroyZombiesWhenNotNeeded();
	}
	
	void SpawnZombie(){
	}
	
	/// <summary>
	/// Destroies the zombies when not needed--when they are not in
	/// the screen anymore.
	/// </summary>
	void DestroyZombiesWhenNotNeeded(){
		foreach (GameObject clone in clones){
			if (clone && clone.transform.position.y < Camera.main.transform.position.y - 2f*Camera.main.orthographicSize){
				DestroyImmediate (clone);
			}
		}
	}
}
