var target : GameObject;

function Update () {
		if (Input.GetKeyDown("mouse 0") || Input.GetKeyDown("mouse 1")){
			target.SetActive(true);
		}
}