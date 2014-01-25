var button : OT_button;
var turn_on : GameObject;
var turn_off : GameObject;


function Start () {
	button = GetComponent("OT_button");
}

function Update () {
	if (button.clicked){
		
		if(turn_on!=null){
			turn_on.SetActive(true);
		}
		if(turn_off!=null){
			turn_off.SetActive(false);
		}
		
		if(Time.timeScale == 1){
			Time.timeScale = 0;
		}else{
			Time.timeScale = 1;
		}
	}
}