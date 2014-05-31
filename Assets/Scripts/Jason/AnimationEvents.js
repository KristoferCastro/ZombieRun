// This JavaScript function can be called by an Animation Event
var target : GameObject;

function TurnOff () {
	gameObject.SetActive(false);
}

function TurnOffTarget () {
	target.SetActive(false);
}

function TurnOn (){
	target.SetActive(true);
}

function PlaySound(){
   audio.Play();
}
