using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OT_PlayerJoin : MonoBehaviour {

	public Texture2D [] characters;	
	public List<ent_Player> AvailablePlayers;
	
	bool is_playing = false;

	void Start()
	{
	}

	void OnGUI ()
	{

		int playerIndex = 0;
		foreach(ent_Player player in AvailablePlayers)
		{
			
			float screenCentre = (Screen.width / 2);
			float totalWidth = 150*AvailablePlayers.Count;
			float startX = screenCentre - (totalWidth/2);


			GUI.DrawTexture(
				new Rect(startX + (playerIndex*150), Screen.height-130, 115, 115), 
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

				} // close if(player.ChangeTimeout <= 0)
				
			} // close if(Input.GetAxis (input_axis) > 0)
			
		} // close foreach(ent_Player player in AvailablePlayers)

		
				
		if(Input.GetAxis ("start") != 0 && !is_playing)
		{
			
			is_playing = true;

			Dictionary<int, int> AlivePlayers = new Dictionary<int, int>();
			for(int i_player = 0; i_player < AvailablePlayers.Count; i_player++)
			{

				ent_Player player = AvailablePlayers[i_player];
				
				if(player.ActiveImage != 0)
				{
					AlivePlayers.Add(i_player, player.ActiveImage);
				} // close if(player.ActiveImage != 0)

			} // close foreach (ent_Player player in AvailablePlayers)




			// left keyset wants right player(-1)
			List<int> alivePlayerList = new List<int>();
			foreach(KeyValuePair<int, int> entry in AlivePlayers)
			{

				int key = entry.Key+1;
				int value = entry.Value-1;

				alivePlayerList.Add(value);

				switch(key)
				{
				case 1:
					AvailablePlayers[value].movementControls = MovementControls.Movement_01;
					break;
				case 2:
					AvailablePlayers[value].movementControls = MovementControls.Movement_02;
					break;
				case 3:
					AvailablePlayers[value].movementControls = MovementControls.Movement_03;
					break;
				case 4:
					AvailablePlayers[value].movementControls = MovementControls.Movement_04;
					break;
				case 5:
					AvailablePlayers[value].movementControls = MovementControls.Movement_05;
					break;
				case 6:
					AvailablePlayers[value].movementControls = MovementControls.Movement_06;
					break;
				}
				
			} // close foreach(KeyValuePair<string, string> entry in AlivePlayers)

			
			for(int i_player = 0; i_player < AvailablePlayers.Count; i_player++)
			{
				if(!alivePlayerList.Contains(i_player))
				{
					AvailablePlayers[i_player].GetComponent<ent_Statistics>().Kill();
					AvailablePlayers[i_player].IsRespawning = false;
					AvailablePlayers[i_player].permaDeath = true;
				}
			}
			
		} // close if(Input.GetAxis ("start") != 0 && !is_playing)
		
	}
}
