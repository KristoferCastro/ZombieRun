#pragma strict

var player : Transform;
var power : float;
var jewel : Transform;
var point : GameObject;
var fade : float = 0.1f;
var distance : float = 10;
     

function Update() {
    if (Vector3.Distance(jewel.position, player.position) < distance) {
    	if (GlobalVariables.eDis >= power){
    		point.SetActive(true);
    	}    	
    } else {
    	point.SetActive(false);
    }
}