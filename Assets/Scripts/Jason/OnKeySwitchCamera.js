var player : GameObject;
var cam1: GameObject;
var cam2: GameObject;

function Update () {
		if (Input.GetKeyDown("s") || Input.GetKeyDown("mouse 1")){
			cam1.SetActive(false);
			cam2.SetActive(true);
			player.GetComponent(CharacterController).enabled = true;
		}
}