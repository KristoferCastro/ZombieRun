using UnityEngine;
using System.Collections;

public class TimedTurnOff : MonoBehaviour {
	public float timer = 25f;
	public GameObject obj;
	
	void Start () {
			StartCoroutine("DisplayScene");
	}
	
	IEnumerator DisplayScene() {
		yield return new WaitForSeconds(timer);
		obj.SetActive(false);
	}
}
