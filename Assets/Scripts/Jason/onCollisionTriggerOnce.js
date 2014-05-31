var triggered : boolean = false;
var effect : GameObject;
var obj: GameObject;
var energyLight : GameObject;

function OnTriggerEnter (other : Collider) {
	if (triggered == false){
		effect.particleSystem.Play();
		obj.animation.Play();
		GlobalVariables.eDis += 10;
		energyLight.light.intensity +=1;
		triggered = true;
	}
}