var playAnim : boolean = true;
var animation_name : String = "ballon";

function Update(){ 
    if (playAnim)
        WaitSeconds(); //wait random seconds for animation
}

function WaitSeconds () {  
    playAnim = false;              
    var randomWait = Random.Range(0, 6);                             
    yield WaitForSeconds(randomWait);                
    animation.Play(animation_name);             
}