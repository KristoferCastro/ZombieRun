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
	public float acceleration;
	
	
	
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = new Vector2(0, speed);
	}
	
	// Update is called once per frame
	void Update () {
	
	
	}
}
