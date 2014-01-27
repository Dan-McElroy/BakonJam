#pragma strict
var turnON : GameObject;

function Start () {

}

function Update () {
	if (Input.GetKeyDown ("w") || Input.GetKey(KeyCode.UpArrow)){
		turnON.SetActive(true);	
	}

}