#pragma strict
var button : OT_button;
var turn_on : GameObject;
var turn_on2 : GameObject;
var turn_off : GameObject;
var turn_off2 : GameObject;
var turn_off3 : GameObject;

var delay: float =0f;
private var timeout : float=1000000000f;

function Start () {
	button = GetComponent("OT_button");
}

function Update () {
	if (button.clicked){
		timeout = Time.time + delay;
		//button.clicked = false;
	}
	
	if (Time.time > timeout){
		if(turn_on!=null){
			turn_on.SetActive(true);
		}
		
		if(turn_on2!=null){
			turn_on2.SetActive(true);
		}
		
		if(turn_off!=null){
			turn_off.SetActive(false);
		}
		
		if(turn_off2!=null){
			turn_off2.SetActive(false);
		}
		
		if(turn_off3!=null){
			turn_off3.SetActive(false);
		}
		timeout = 1000000000f;
	}
}