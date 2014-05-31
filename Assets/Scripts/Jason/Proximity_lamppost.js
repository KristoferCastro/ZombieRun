#pragma strict

var cylinder : Transform;
var player : Transform;
var source : Transform;
var point : GameObject;
     

function Update() {
	var distanceLimit = GlobalVariables.eDis;
    if (Vector3.Distance(cylinder.position, player.position) < distanceLimit || source.active == true) {
    	point.light.enabled = true;
    } else {
    	point.light.enabled = false;
    }
}
