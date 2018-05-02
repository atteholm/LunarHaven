using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	
	public GameObject player;

	void Update ()
	{
		
		// Try catch prevents console flood
		try {
			// Copies the player position to the camera position
			transform.position = player.transform.position;
		} catch (UnassignedReferenceException) {

		}
	}
}
