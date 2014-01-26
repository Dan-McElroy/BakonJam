using UnityEngine;
using System.Collections;

public class snd_Manager : MonoBehaviour {

	public static snd_Manager Instance;

	public string[] clipNames;
	public AudioClip[] clips;

	void Awake () 
	{
		if (Instance != null) 
		{
			print ("Multiple instances of Sound Manager.");
		}
		Instance = this;
	}

	void PlaySound(string clipName)
	{
		int index = 0;
		while (clipNames[index] !=  clipName)
		{
			index++;
		}
		AudioSource.PlayClipAtPoint (clips[index], transform.position);
	}
}
