using UnityEngine;
using System.Collections;

public class ProgressHUD : MonoBehaviour {
	
	public Transform startPoint;
	public Transform endPoint;
	public Transform playerIcon;
	
	float totalDistance; // of progress bar
	
	Progress progressScript;
	// Use this for initialization
	void Start () {
		InitializeReferences();
		
		totalDistance = endPoint.position.y - startPoint.position.y;
	}
	
	void InitializeReferences(){
		if (startPoint == null)
			startPoint = GameObject.Find(GameObjectIDS.PROGRESS_HUD_START).transform;
		if (endPoint == null)
			endPoint = GameObject.Find(GameObjectIDS.PROGRESS_HUD_END).transform;
		if (playerIcon == null)
			playerIcon = GameObject.Find (GameObjectIDS.PROGRESS_PLAYER_ICON).transform;
		if (progressScript == null)
			progressScript = GameObject.Find(GameObjectIDS.PROGRESS_MANAGER).GetComponent<Progress>();
	}
	
	// Update is called once per frame
	void Update () {		
		playerIcon.position = new Vector3(playerIcon.position.x, totalDistance*progressScript.progress/100,
		                                  playerIcon.position.z);
	}
}
