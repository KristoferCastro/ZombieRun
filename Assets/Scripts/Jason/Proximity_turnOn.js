#pragma strict

var target : GameObject;
     
function OnTriggerEnter(otherObj: Collider){
    if (otherObj.tag == "Player"){
        target.SetActive(true);
    }
}

function OnTriggerExit(otherObj: Collider){
    if (otherObj.tag == "Player"){ 
        target.SetActive(false);
    }
}