using UnityEngine;
using System.Collections;

public class OnCollisionGameOver : MonoBehaviour {

	public GameObject player;
	public GameObject fade;
	public string tag = "Player";
	public string level = "Scene Name";
	bool fading = false;
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == tag && !fading){
			StartCoroutine(Death()); 
		}
	}

	IEnumerator Death(){
		fading = true;
		fade.SetActive(true);
		player.audio.Play();
		player.GetComponent<PlayerController>().enabled = false;
		GameObject.Find("ProgressHUD").SetActive(false);
		yield return new WaitForSeconds (4f);
		Application.LoadLevel(level);
	}
}
