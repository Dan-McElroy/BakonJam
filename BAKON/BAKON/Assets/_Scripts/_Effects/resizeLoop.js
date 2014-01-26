var time :float  =  4f;
var scaleby : float = 1.2f;
var tween: iTween;

function StartTween(){
		iTween.ScaleTo(gameObject,iTween.Hash(
											"scale",Vector3(transform.localScale.x * scaleby,transform.localScale.y * scaleby,transform.localScale.z * scaleby),
											"time",time,
											"easetype","easeInOutSine",
											"islocal",true,
											"looptype","pingPong"
		));								
}

function Update(){
	tween =  GetComponent(iTween);
	if (tween== null){
		StartTween();
	}
}
// TO DO IF NO ITWEEN COMPONENT START TO RESIZE
