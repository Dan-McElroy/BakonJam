#pragma strict
var nextCheck : float = 0;
var s_render : SpriteRenderer;


function Start () {
	s_render = GetComponent(SpriteRenderer);
}


function Update () {
	if(Time.time> nextCheck){
		if(!GetComponent(BoxCollider2D).enabled){
			s_render.enabled =!s_render.enabled;
		}else{
			s_render.enabled =true;
		}
		
		nextCheck = Time.time+0.05; 
		
		//SPRITE ON AND OFF
		
	}
}