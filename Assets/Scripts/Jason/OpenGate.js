var animationSwitch : boolean = false;
var obj: GameObject;
var power : float;

function OnTriggerEnter (other : Collider) {
	if (!animationSwitch && GlobalVariables.eDis >= power){
		obj.animation.Play();   
		animationSwitch = true;
	}
}