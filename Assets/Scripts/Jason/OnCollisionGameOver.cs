using UnityEngine;
using System.Collections;

public class OnCollisionGameOver : MonoBehaviour {

	public GameObject player;
	public GameObject fade;
	public string tag = "Player";
	public string level = "Scene Name"; 
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == tag){
			player.GetComponent<PlayerController>().enabled = false;
			player.audio.Play();
			GameObject.Find("ProgressHUD").SetActive(false);
			fade.SetActive(true);
			StartCoroutine(Death()); 
		}
	}

	IEnumerator Death(){
		yield return new WaitForSeconds (3f);
		Application.LoadLevel(level);
	}
}
