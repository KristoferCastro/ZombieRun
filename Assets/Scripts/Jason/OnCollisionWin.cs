using UnityEngine;
using System.Collections;

public class OnCollisionWin : MonoBehaviour {
	
	public GameObject player;
	public GameObject fade;
	public GameObject spawners;
	public string tag = "Player";
	public string level = "Scene Name";
	bool winning = false;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == tag && !winning){
			StartCoroutine(Win()); 
		}
	}
	
	IEnumerator Win(){
		winning = true;
		//fade.SetActive(true);
		//player.audio.Play();
		spawners.SetActive(false);


		player.animation.Play();
		player.GetComponent<PlayerController>().enabled = false;
		GameObject.Find("ProgressHUD").SetActive(false);

		yield return new WaitForSeconds (5f);
		//Application.LoadLevel(level);
	}
}
