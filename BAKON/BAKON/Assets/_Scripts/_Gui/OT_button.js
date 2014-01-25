//BUTTON CLASS WHEN MOUSE OVER THE BUTTON ENLARGES THEN

var clicked : boolean = false;
var clickscale : float = 0.9f;

var clickover : boolean = false;
var startScale : Vector3;

var GUICAMERA : Camera;
var Scale_Parent : boolean = false;


function Start () {
 	startScale = transform.localScale;
 //print (startScale);
 	if (Scale_Parent){
		startScale = transform.parent.localScale;
	}
}

function OnEnable() {
	clicked = false;
}

function Update () {
	
	var o : GameObject = gameObject;
	
	if (Scale_Parent){
		o = transform.parent.gameObject;
	}
	
	if(clicked){
		clicked = false; // RESET BUTTON AFTER CLICK -> ALLOWS FOR STACKING MULTIPLE BUTTONS TOGETHER
	}

	if ( Input.GetMouseButtonDown(0)){
		clicked = false;
		if(rayhittest()){
			
			iTween.ScaleTo(o,iTween.Hash(
										"scale",Vector3(startScale.x*clickscale,startScale.y*clickscale,startScale.z*clickscale),
										"time",0.5f,
										"ignoretimescale",true
									));

			//iTween.ScaleTo(gameObject, Vector3(startScale.x*clickscale,startScale.y*clickscale,0), 0.5f);
			clickover = true;
		}
	}
	
	if ( Input.GetMouseButtonUp(0) && clickover){
		clickover = false;
		//_game_variablesB.GUIclicked = false;
		
		iTween.ScaleTo(o, startScale, 0.2f);
		
		if(rayhittest()){
			//CLICK RELEASED OVER BUTTON EXECUTE SOUND
			clicked = true;
			
			
		}else{
			clicked = false;
			
		}
	}	
}

function rayhittest ()
{
		var hit : RaycastHit;
		var ray : Ray ;
		
		var hit2d : RaycastHit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if(hit2d.collider != null)
        {
            Debug.Log("object clicked: "+hit2d.collider.tag);
        }
		
		
		if (hit2d.collider.gameObject == gameObject)
		{
				//print("clicked");
				return true;
		}
		
		return false;
}