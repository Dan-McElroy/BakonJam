#pragma strict
var button : OT_button;
var turn_on : GameObject;
var findName : String ="";
var delay: float =0f;
private var timeout : float=1000000000f;

function Start () {
	button = GetComponent("OT_button");
	
	if(findName!=""){
		turn_on = GameObject.Find(findName);
	}
}

function Update () {
	if (button.clicked){
		timeout = Time.time + delay;
		button.clicked = false;
		
		if(turn_on!=null && turn_on.active){
			turn_on.SetActive(false);
			// DEACTIVATE  SOUND LISTER instead
		}else{
			turn_on.SetActive(true);
			// ACTIVATE  SOUND LISTER instead
		}

	}

}