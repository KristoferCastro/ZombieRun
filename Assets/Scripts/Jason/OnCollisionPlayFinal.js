var animationSwitch : boolean = false;
var player : GameObject;
var maincam : GameObject;
var cam : GameObject;
var animholder : GameObject;

function OnTriggerEnter (other : Collider) {
	if (!animationSwitch){	
		//player.GetComponent(MouseLook).enabled = false;
		//maincam.GetComponent(MouseLook).enabled = false;
		player.GetComponent(CharacterController).enabled = false;
		maincam.SetActive(false);
		cam.SetActive(true);
		animholder.animation.Play();
		animationSwitch = true;
	}
}