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

	readonly float BASE_SPEED = 1f;
	public float speed;
	public float acceleration = 0.0005f;
	public bool followPlayerEverywhere = false;
	public bool following = false;
	
	
	SearchRadar searchRadar;
	public GameObject player;	
	protected PlayerController playerControl;
	protected Quaternion originalRotation;
	
	public float moveForce = 2f;
	
	// how much should we push the player
	public float leapForce = 50f;
	
	bool leaping;
	
	protected void Start () {
		InitializeReferences();
		InitializeVariables();
		originalRotation = transform.rotation;
		IgnoreCollisionsWithBus(true);
	}
	
	protected void IgnoreCollisionsWithBus(bool decision){
		GameObject bus = GameObject.FindGameObjectWithTag(GameObjectIDS.BUS_TAG);
		Physics2D.IgnoreLayerCollision(gameObject.layer, bus.layer, decision);
	}
	
	
	void InitializeVariables(){
		originalRotation = transform.rotation;
		leaping = false;
		playerControl = player.GetComponent<PlayerController>();
	}
	
	void InitializeReferences(){
		if ( player == null )
			player = GameObject.Find(GameObjectIDS.PLAYER);
		searchRadar = gameObject.GetComponentInChildren<SearchRadar>();
	}
	
	protected void Update () {
		//speed += acceleration;
		//rigidbody2D.velocity = new Vector2(0, speed);
				
		if (searchRadar.FoundPlayer || followPlayerEverywhere){
			LookAt (player);
			following = true;
			if (!leaping){
				leaping = true;
				LeapAtPlayer();
			}
		}
		else{
			ResetZombie();
			following = false;
			
		}
	}
	
	protected void FixedUpdate(){
		ChangeSpeedBasedOnPlayer();
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
	
	void ChangeSpeedBasedOnPlayer(){
		
		if (playerControl.speedState == PlayerController.IDLE){
			if (speed < BASE_SPEED )
				speed = BASE_SPEED;
			else 
				speed -= 0.00085f;
		}else if (playerControl.speedState == PlayerController.VERY_SLOW){
			speed += 0.0001f;
		}else if (playerControl.speedState == PlayerController.MODERATE){
			speed += 0.0009f;
		}else if (playerControl.speedState == PlayerController.FAST){
			speed += 0.0020f;
		}else if (playerControl.speedState == PlayerController.VERY_FAST){
			speed += 0.0045f;	
		}
	}
}
