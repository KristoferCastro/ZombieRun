var animationSwitch : boolean = false;
var player: GameObject;
var cam: GameObject;

function OnTriggerEnter (other : Collider) {
	if (!animationSwitch){
		//player.GetComponent(MouseLook).enabled = false;
		player.GetComponent(CharacterController).enabled = false;
		//cam.GetComponent(MouseLook).enabled = false;
		cam.animation.Play();
		animationSwitch = true;
	}
}