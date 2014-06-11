using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {

	public GameObject player;
	public Transform cameraLeftBound;
	public Transform cameraRightBound;

	float cameraWidth;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (OutOfBound ()) {
				//only follow vertically
				transform.position = transform.position = new Vector3 (transform.position.x, player.transform.position.y,
	                                                      transform.position.z);
		} else {
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y,
			                                 transform.position.z);
		}

	}

	bool OutOfBound(){
		float cameraHeight = 2f * camera.orthographicSize;
		float cameraWidth = camera.orthographicSize*camera.aspect;

		// note these aren't the actual camera edges its what
		// the camera edges would be if it was ALWAYS following the player
		float cameraLeftEdge = player.transform.position.x - cameraWidth;
		float cameraRightEdge = player.transform.position.x + cameraWidth;

		Debug.Log ("left: " + cameraLeftEdge + ", bound: " + cameraLeftBound.position.x);
		if (cameraLeftEdge < cameraLeftBound.position.x || cameraRightEdge > cameraRightBound.position.x)
						return true;
		return false;
	}
}
