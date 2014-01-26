using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OT_PlayerJoin : MonoBehaviour {

	public Texture2D [] characters;
	public Vector2 DrawStartPoint = new Vector2(100, 100);
	public List<ent_Player> AvailablePlayers;

	void Start()
	{
	}

	void OnGUI ()
	{

		int playerIndex = 0;
		foreach(ent_Player player in AvailablePlayers)
		{
			
			GUI.DrawTexture(
				new Rect(DrawStartPoint.x + (playerIndex*150), DrawStartPoint.y, 115, 115),
				characters[player.ActiveImage],
				ScaleMode.ScaleToFit,
				true, 
				0
			);

			if(player.ChangeTimeout > 0)
			{
				player.ChangeTimeout -= Time.deltaTime;
			}
			
			playerIndex++;

			string input_axis = string.Format("Vertical_0{0}", playerIndex);
			if(Input.GetAxis (input_axis) > 0)
			{
				
				if(player.ChangeTimeout <= 0)
				{
					int next_active = player.ActiveImage+1;

					
					
					// Get list of indeces already used
					List<int> existingChoice = new List<int>();
					foreach(ent_Player player2 in AvailablePlayers)
					{
						if(player2 != player)
						{
							existingChoice.Add(player2.ActiveImage);
						}
					}

					// Set next active to first available free 
					if(existingChoice.Contains(next_active))
					{
						while(existingChoice.Contains(next_active))
						{
							next_active++;
						}
					}


					// Ensure next active is within available range
					if(next_active < characters.Length)
					{
						player.ActiveImage = next_active;
					}
					else
					{
						player.ActiveImage = 0;
					}

					// Create timeout to stop change too rapidly
					player.ChangeTimeout = 0.8f;
				}
				
			}

		}


		if(Input.GetAxis ("start") != 0)
		{
			foreach (ent_Player player in FindObjectsOfType(typeof(ent_Player)) as ent_Player[])
			{
				if(player.ActiveImage == 0)
				{
					player.GetComponent<ent_Statistics>().Kill();
					player.IsRespawning = false;
				}
			}

		}

		
	}
}
