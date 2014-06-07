using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	public AudioClip running;
	
	public float maxSpeed = 20f;
	public float speed = 0f;
	public float acceleration = 0.3f;
	public float deceleration = 2.5f;
	//public float decelerationScalar = 1f;
	
	enum Looking : byte {Up = 0, Down, Left, Right, UpLeft, UpRight, DownLeft, DownRight}
	
	Looking previousLookingState;
	Looking lookingState;
	char lastKey;
	
	Quaternion originalRotation;
		
	
	// Use this for initialization
	void Start () {
		originalRotation = 	transform.rotation;
		lastKey = 'a';
	}
	
	// Update is called once per frame
	void Update () {
		MapInputToState();
		Move();	
		Point();
	}
	
	void FixedUpdate(){
	}
	
	/// <summary>
	/// Alternately pressing two keys make the player move faster
	/// </summary>
	void Move(){
		Debug.Log ("Speed: " + speed);
				
		if (Input.GetKeyDown("a")){
			// if succesfully alternating, speed up
			if ( lastKey == 'd' && speed <= maxSpeed){
				speed += acceleration;
			}
			lastKey = 'a';
			
		}
		
		else if (Input.GetKeyDown ("d")){
			if ( lastKey == 'a' && speed <= maxSpeed){
				speed += acceleration;
			}
			lastKey = 'd';
		}
			
		if ( speed <= 0 )
			speed = 0;
		else
			speed -= deceleration*Time.deltaTime;
	}
	
	/// <summary>
	/// Maps the speed to a more human readable one
	/// </summary>
	/// <returns>The speed to force.</returns>
	float MapSpeedToForce(){
		//return speed *
		return 0;
	}
	
	void Point(){
		switch(lookingState){
		case Looking.Up:
			if (lookingState != previousLookingState){
				ResetState();	
			}
			rigidbody2D.velocity = new Vector2(0, speed);
			previousLookingState = lookingState;
			break;
		case Looking.Down:
			if (lookingState != previousLookingState){
				ResetState();
				transform.Rotate(Vector3.forward*-180);
			}
			rigidbody2D.velocity = new Vector2(0, -speed);
			previousLookingState = lookingState;
			break;
		case Looking.Left:
			if (lookingState != previousLookingState){
				ResetState();
				transform.Rotate(Vector3.forward*90);		
			}
			rigidbody2D.velocity = new Vector2(-speed, 0);
			previousLookingState = lookingState;
			break;
		case Looking.Right:
			if (lookingState != previousLookingState){
				ResetState();
				transform.Rotate(Vector3.forward*-90);
			}
			rigidbody2D.velocity = new Vector2(speed, 0);
			previousLookingState = lookingState;
			break;
		case Looking.UpLeft:
			if (lookingState != previousLookingState){
				ResetState();
				transform.Rotate(Vector3.forward*45);
			}
			rigidbody2D.velocity = new Vector2(-speed, speed);
			previousLookingState = lookingState;
			break;
		case Looking.UpRight:
			if (lookingState != previousLookingState){
				ResetState();
				transform.Rotate(Vector3.forward*-45);
			}
			rigidbody2D.velocity = new Vector2(speed, speed);		
			previousLookingState = lookingState;
			break;
		case Looking.DownLeft:
			if (lookingState != previousLookingState){
				ResetState();
				transform.Rotate(Vector3.forward*-225);
			}
			rigidbody2D.velocity = new Vector2(-speed, -speed);
			previousLookingState = lookingState;
			break;
		case Looking.DownRight:
			if (lookingState != previousLookingState){
				ResetState();
				transform.Rotate(Vector3.forward*-135);
			}
			rigidbody2D.velocity = new Vector2(speed, -speed);
			previousLookingState = lookingState;
			break;
		default :
			//lookingState = Looking.Up;
			break;
		}
	}
	
	/// <summary>
	/// Resets the state to false.
	/// </summary>
	void ResetState(){
		transform.rotation = originalRotation;
		rigidbody2D.velocity = new Vector2(0, 0);
	}
	
	/// <summary>
	/// Maps control to state.  If we want to change the key controls, change them here,
	/// without changing anywhere else.
	/// </summary>
	void MapInputToState(){
		if (Input.GetKey(KeyCode.UpArrow)){
			
			if (Input.GetKey (KeyCode.LeftArrow) ){
				lookingState = Looking.UpLeft;
			}
			else if (Input.GetKey (KeyCode.RightArrow)){
				lookingState = Looking.UpRight;
			}
			else{
				lookingState = Looking.Up;
			}
		}
		else if (Input.GetKey (KeyCode.DownArrow) ){
			if (Input.GetKey (KeyCode.LeftArrow) ){
				lookingState = Looking.DownLeft;
			}
			else if (Input.GetKey (KeyCode.RightArrow)){
				lookingState = Looking.DownRight;
			}
			else{
				lookingState = Looking.Down;
			}
		}
		else if (Input.GetKey (KeyCode.DownArrow)){
			if (Input.GetKey (KeyCode.LeftArrow) ){
				lookingState = Looking.DownLeft;				
			}
			else if (Input.GetKey (KeyCode.RightArrow)){
				lookingState = Looking.DownRight;	
			}
			
		}	
		else if (Input.GetKey (KeyCode.LeftArrow)){
			lookingState = Looking.Left;		
		}	
		else if (Input.GetKey (KeyCode.RightArrow)){
			lookingState = Looking.Right;				
		}		
	}
	
}

//balls
