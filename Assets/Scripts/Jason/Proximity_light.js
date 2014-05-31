#pragma strict

var cylinder : Transform;
var player : Transform;
var point : GameObject;
var bulb : GameObject;
     

function Update() {
	var distanceLimit = GlobalVariables.eDis;
    if (Vector3.Distance(cylinder.position, player.position) < distanceLimit) {
    	point.light.enabled = true;
    	bulb.SetActive(true);
    } else {
    	point.light.enabled = false;
		bulb.SetActive(false);
    }
}
