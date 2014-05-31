using UnityEngine;
using System.Collections;

public class RayLockActivate : MonoBehaviour {
	public GameObject obj;
    void Update() {
		Screen.showCursor = false; 
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (!Physics.Raycast(transform.position, fwd, 10)){
			obj.SetActive(true);
			this.GetComponent<MouseLook>().enabled = false;
		}
    }
}