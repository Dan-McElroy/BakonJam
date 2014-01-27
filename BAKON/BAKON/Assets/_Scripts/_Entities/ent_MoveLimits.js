#pragma strict
var max_x : float = 18;
var min_x : float = -18;
var max_y : float = 18;
var min_y : float = -18;


function Update () {
	if( transform.position.x>max_x ){
		transform.position.x=max_x;
	}
	
	if( transform.position.x<min_x ){
		transform.position.x=min_x;
	}
	
	if( transform.position.y>max_y ){
		transform.position.y=max_y;
	}
	
	if( transform.position.y<min_y ){
		transform.position.y=min_y;
	}

}