#pragma strict
var targetbegin : GameObject;
var targetend : GameObject;

function Start () {
	if (GlobalVariables.end == true){
		targetbegin.SetActive(false);
		targetend.SetActive(true);	
	}
}