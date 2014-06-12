using UnityEngine;
using System.Collections;

public class LoadSceneOnKey : MonoBehaviour {

	public GameObject blankImage;
	public string level = "Scene Name"; 
	public bool on = true;
	bool fading = false;

	void Update () {
		if(Input.GetKeyDown("space") && !fading && on){
			fading = true;
			blankImage.SetActive(true);
			StartCoroutine(FadeMusicLoadLevel()); 
		}
	}

	IEnumerator FadeMusicLoadLevel(){
		for (float i = 9; i > 0; i--){
			audio.volume = audio.volume - audio.volume * 0.3f;
			yield return new WaitForSeconds (0.35f);
		}
		Application.LoadLevel(level);
	}

}