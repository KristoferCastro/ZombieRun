using UnityEngine;
using System.Collections;

public class PushingZombie : ZombieAI {

	float pushforce = 200f;
	float fadeTime = 1.5f;
	bool fading = false;
	Color color;
	
	void Start(){
		base.Start();
		speed = 20.0f;
		FaceDownwards();
		base.originalRotation = transform.rotation;
	}
	
	void Update(){
		base.Update();
		
		FadeCheck();
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
			other.gameObject.rigidbody2D.AddForce(Vector3.down * pushforce);	
			fading = true;	
			
			// player can't move
			other.gameObject.GetComponent<PlayerController>().enabled = false;
			
		}
	}
	
	
	void FixedUpdate(){
		base.FixedUpdate();
	}
	
	void FaceDownwards(){
		gameObject.transform.Rotate(new Vector3(0,0, 180));
	}
}
