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
	
	protected Quaternion originalRotation;
	
	public float moveForce = 2f;
	
	// how much should we push the player
	public float leapForce = 50f;
	
	bool leaping;
	
	protected void Start () {
		
		InitializeVariables();
		InitializeReferences();
		IgnoreCollisionsWithBus(true);
		originalRotation = transform.rotation;
	}
	
	protected void IgnoreCollisionsWithBus(bool decision){
		GameObject bus = GameObject.FindGameObjectWithTag(GameObjectIDS.BUS_TAG);
		Physics2D.IgnoreLayerCollision(gameObject.layer, bus.layer, decision);
	}
	
	void InitializeVariables(){
		originalRotation = transform.rotation;
		leaping = false;
	}
	
	void InitializeReferences(){
		player = GameObject.Find(GameObjectIDS.PLAYER);
		searchRadar = gameObject.GetComponentInChildren<SearchRadar>();
	}
	
	protected void Update () {
		//speed += acceleration;
		//rigidbody2D.velocity = new Vector2(0, speed);
				
		if (searchRadar.FoundPlayer){
			LookAt (player);
			
			if (!leaping){
				leaping = true;
				LeapAtPlayer();
			}
		}
		else{
			ResetZombie();
		}
	}
	
	protected void FixedUpdate(){
		rigidbody2D.AddRelativeForce(Vector3.up*speed);
	}
	
	void ResetZombie(){
		leaping = false;
		if (transform.rotation != originalRotation){
			float scalingFactor = 0.5f;
			transform.rotation = Quaternion.Slerp (transform.rotation, originalRotation, 
			                                       Time.deltaTime/scalingFactor);
		}
	}
	
	IEnumerator LeapAtPlayer(){
		rigidbody2D.AddRelativeForce(Vector3.up*leapForce);
		yield return new WaitForSeconds(2);
		
	}
	
	void LookAt(GameObject target){
		Vector3 diff = target.transform.position - gameObject.transform.position;
		float rot_z = Mathf.Atan2 (diff.x, diff.y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f,0f, -rot_z);
	}
}
