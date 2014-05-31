function OnTriggerEnter(otherObj: Collider){
    if (otherObj.tag == "Player"){
        audio.Play();
    }
}

function OnTriggerExit(otherObj: Collider){
    if (otherObj.tag == "Player"){ 
        audio.Stop();
    }
}