using UnityEngine;
using System.Collections;

/// <summary>
/// This class handles how one Zombie act in the game.
///	
///	Behaviour:
///		1.  They move towards the top at a starting velocity
///		2.	Once they get close enough, zombies come at the player one by one
///			essentially throwing their bodies at the player!
///		3.  Once a zombie touches a player, the player loses
///
///		Do Zombies get increasingly faster? Maybe...
/// </summary>
public class ZombieAI : MonoBehaviour {

	public float speed = 0.5f;
	public float acceleration = 0.0005f;
	
	
	SearchRadar searchRadar;
	GameObject player;
	
	Quaternion originalRotation;
	
	public float moveForce = 2f;
	
	// how much should we push the player
	public float pushForce = 100f;
	
	void Start () {
	
		InitializeReferences();
		originalRotation = transform.localRotation;
	}
	
	void InitializeReferences(){
		player = GameObject.Find(GameObjectIDS.PLAYER);
		searchRadar = gameObject.GetComponentInChildren<SearchRadar>();
	}
	
	void Update () {
		//speed += acceleration;
		//rigidbody2D.velocity = new Vector2(0, speed);
				
		if (searchRadar.FoundPlayer){
			Debug.Log ("Found a player");
			LookAt (player);
		}
	}
	
	void FixedUpdate(){
		rigidbody2D.AddRelativeForce(Vector3.up*speed);
	}
	
	IEnumerator ResetRotation(){
		if (transform.rotation != originalRotation){
			//transform.rotation += originalRotation/100;
			yield return null;
		}
	}
	
	void LookAt(GameObject target){
		Vector3 diff = target.transform.position - gameObject.transform.position;
		float rot_z = Mathf.Atan2 (diff.x, diff.y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f,0f, -rot_z);
	}
}
