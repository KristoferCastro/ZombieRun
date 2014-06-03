using UnityEngine;
using System.Collections;

public class BusCleanUp : MonoBehaviour {

	bool seenOnce;
	// Use this for initialization
	void Start () {
		seenOnce = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (WeCanSeeOnScreen())
			seenOnce = true;
		
		if (seenOnce && WeCanSeeOnScreen() && gameObject.name.Contains("(Clone)")){	
				//Destroy(gameObject);		
		}
			
	}
	
	bool WeCanSeeOnScreen(){
		return renderer.isVisible;
	}
}
