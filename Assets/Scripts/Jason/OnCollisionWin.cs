using UnityEngine;
using System.Collections;

public class OnCollisionWin : MonoBehaviour {
	
	public GameObject player;
	public GameObject topWall;
	public GameObject mainCamera;
	public GameObject victoryCamera;
	public GameObject winSplat;
	public string tag = "Player";
	public string level = "Scene Name";
	bool winning = false;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		mainCamera.GetComponent<LoadSceneOnKey>().on = true;
		if (other.gameObject.tag == tag && !winning){
			StartCoroutine(Win()); 
		}
	}
	
	IEnumerator Win(){
		winning = true;

		player.animation.Play();
		player.GetComponent<PlayerController>().enabled = false;
		GameObject.Find("ProgressHUD").SetActive(false);
		topWall.SetActive(true);
		mainCamera.GetComponent<Camera>().enabled = false;
		victoryCamera.GetComponent<Camera>().enabled = true;
		victoryCamera.animation.Play();
		victoryCamera.audio.Play();
		for (float i = 9; i > 0; i--){
			mainCamera.audio.volume = mainCamera.audio.volume - mainCamera.audio.volume * 0.3f;
			yield return new WaitForSeconds (0.35f);
		}
		player.GetComponent<PlayerController>().enabled = false;
		winSplat.SetActive(true);


		//Application.LoadLevel(level);
	}
}
