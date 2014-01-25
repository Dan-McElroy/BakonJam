var turn_on : GameObject;
var turn_off : GameObject;
var music : boolean =  true;

function Start () {

}


function Update () {
	if ( Input.GetMouseButtonDown(0)){
		if(turn_on!=null){
			turn_on.SetActive(true);
		} 
		
		if(turn_off!=null){
			turn_off.SetActive(false);
		}
		
		Time.timeScale = 1;
	}
}