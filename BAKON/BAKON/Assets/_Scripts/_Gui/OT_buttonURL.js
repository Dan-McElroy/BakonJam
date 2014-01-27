#pragma strict
var button : OT_button;
var url : String;


function Start () {
	button = GetComponent("OT_button");
}

function Update () {
	if (button.clicked){
			Time.timeScale = 1;
			button.clicked = false;
			Application.OpenURL (url);
	}

}