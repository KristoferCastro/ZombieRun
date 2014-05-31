var triggered : boolean = false;
var obj: GameObject;

function OnTriggerEnter (other : Collider) {
	if (triggered == false){
		obj.SetActive(true);
		triggered = true;
	}
}