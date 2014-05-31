using UnityEngine;
using System.Collections;

public class TimedTurnOn: MonoBehaviour {
	public float timer =5f;
	public GameObject obj;
	
	void Start () {
			StartCoroutine("DisplayScene");
	}
	
	IEnumerator DisplayScene() {
		yield return new WaitForSeconds(timer);
		obj.SetActive(true);
	}
}
