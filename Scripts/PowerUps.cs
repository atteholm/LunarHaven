using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {



	public static bool run = false, doubleJump = false;
	public static int bonusHealth = 0;

	public static void ActivatePowerUp(string name)
	{
		switch (name)
		{
		case "run":
			run = true;
			break;
		case "doubleJump":
			doubleJump = true;
			break;
		case "bonusHealth":
			bonusHealth++;
			break;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
