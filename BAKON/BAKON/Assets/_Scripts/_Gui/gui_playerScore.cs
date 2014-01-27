using UnityEngine;
using System.Collections;

public class gui_playerScore : MonoBehaviour {

	// Use this for initialization

	public ent_Statistics stats;
	 
	
	// Update is called once per frame
	void Update () {
		string score ="";
		if(stats.Score<10){
			score = "0";
		}
		
		GetComponent<TextMesh>().text = score + stats.Score;
		
	}
}
