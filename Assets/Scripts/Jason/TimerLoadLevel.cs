using UnityEngine;
using System.Collections;

public class TimerLoadLevel : MonoBehaviour {
	public float timer;
	public string levelToLoad;
	
	void Start () {
			StartCoroutine("DisplayScene");
	}
	
	IEnumerator DisplayScene() {
		yield return new WaitForSeconds(timer);
		Application.LoadLevel(levelToLoad);
	}
}
