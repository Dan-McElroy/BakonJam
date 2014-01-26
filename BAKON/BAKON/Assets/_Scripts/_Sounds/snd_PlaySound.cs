using UnityEngine;
using System.Collections;

public class snd_PlaySound : MonoBehaviour {

	public string soundName;
	// Use this for initialization
	void OnEnable () {
		snd_Manager.Instance.PlaySound(soundName);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
