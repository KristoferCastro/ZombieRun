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
			StartCoroutine(Death()); 
		}
	}

	IEnumerator Death(){
		player.audio.Play();
		player.GetComponent<PlayerController>().enabled = false;
		GameObject.Find("ProgressHUD").SetActive(false);
		fade.SetActive(true);
		yield return new WaitForSeconds (3f);
		Application.LoadLevel(level);
	}
}
