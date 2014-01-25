#pragma strict
var button : OT_button;

var executeTime : float =0.0f;

function Start () {
	button = GetComponent("OT_button");
}

function Update () {
	if (button.clicked){
			Time.timeScale = 1;
			button.clicked = false;
			executeTime =Time.time+0.5f;
			//Application.LoadLevel(levelname);
			//g_vars.menu = false;
			//g_vars.RestartLevel();
			//FIND LOAD LEVEL GO and ACTIVATE
			GameObject.Find("_GUI_LoadingScreen").renderer.enabled = true;
	}
	
	if (Time.time>executeTime && executeTime>0){
		
		Application.LoadLevel(Application.loadedLevel);
	}
}