using UnityEngine;
using System.Collections;

public class PushingZombie : ZombieAI {

	readonly float BASE_SPEED = 20f;
	readonly float BASE_PUSH_FORCE = 200f;
	readonly float BASE_FADE_TIME = 1.5f;
	float pushforce;
	float fadeTime;
	float followTime = 3.5f;
	bool fading = false;
	Color color;
	
	void Start(){
		base.Start();
		speed = BASE_SPEED;
		pushforce = BASE_PUSH_FORCE;
		fadeTime = BASE_FADE_TIME;
		FaceDownwards();
		base.originalRotation = transform.rotation;
		IgnoreCollisionsWithBus(false);
	}
	
	protected void IgnoreCollisionsWithBus(bool decision){
		GameObject bus = GameObject.FindGameObjectWithTag(GameObjectIDS.BUS_TAG);
		Physics2D.IgnoreLayerCollision(gameObject.layer, bus.layer, decision);
	}
	
	void Update(){
		base.Update();		
		FollowCheck();
		FadeCheck();
		
	}
	
	// can only follow for a certain amount of time
	void FollowCheck(){
		if ( following ){
			color = renderer.material.color;
			color.a -= Time.deltaTime/followTime;
			renderer.material.color = color;
			
			if (color.a <= 0){
				Destroy (gameObject);
				//GameObject.Find(GameObjectIDS.PLAYER).GetComponent<PlayerController>().enabled = true;
			}
		}
	}
	
	void FadeCheck(){		
		if ( fading ){
			color = renderer.material.color;
			color.a -= Time.deltaTime/fadeTime;
			renderer.material.color = color;
			
			if (color.a <= 0){
				Destroy (gameObject);
				GameObject.Find(GameObjectIDS.PLAYER).GetComponent<PlayerController>().enabled = true;
			}
		}
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.name == GameObjectIDS.PLAYER){			
			fadeTime = BASE_FADE_TIME;
			other.gameObject.rigidbody2D.AddForce(Vector3.down * pushforce);	
			if (!fading){
				this.gameObject.audio.Play();
			}
			fading = true;
			// player can't move
			other.gameObject.GetComponent<PlayerController>().enabled = false;			
		}
		
		if (other.gameObject.tag == GameObjectIDS.ZOMBIE_FROM_HORDE_TAG){
			//fading = true;
		}
	}
	
	
	void FixedUpdate(){
		base.FixedUpdate();
		MakeItDifficult();
	}
	
	void FaceDownwards(){
		gameObject.transform.Rotate(new Vector3(0,0, 180));
	}
	
	void MakeItDifficult(){
		if (playerControl.speedState == PlayerController.IDLE){
			speed = BASE_SPEED;
			pushforce = BASE_PUSH_FORCE;
		}else if (playerControl.speedState == PlayerController.VERY_SLOW){
			speed = BASE_SPEED;
			pushforce = BASE_PUSH_FORCE + 25;
		}else if (playerControl.speedState == PlayerController.MODERATE){
			speed = BASE_SPEED + 10;
			pushforce = BASE_PUSH_FORCE + 75;
		}else if (playerControl.speedState == PlayerController.FAST){
			speed = BASE_SPEED + 40;
			pushforce = BASE_PUSH_FORCE + 150;
		}else if (playerControl.speedState == PlayerController.VERY_FAST){
			speed = BASE_SPEED + 55;	
			pushforce = BASE_PUSH_FORCE + 200;
			
		}
	}
}
