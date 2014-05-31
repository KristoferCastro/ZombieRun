using UnityEngine;
using System.Collections;

public class TurnScriptOff : MonoBehaviour
{	
	void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
    }
	
	/*
	GameObject obj;
	void Awake()
	{
		obj.GetComponent<MouseLook>().enabled = true;
	}
	*/
}