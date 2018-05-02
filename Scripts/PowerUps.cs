/// <summary>
/// Power ups.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

	public static int bonusHealth = 0, doubleJump = 0, run = 0, healthPrice = 500 * (bonusHealth + 1), jumpPrice = 1000 * (doubleJump + 1), runPrice = 1000 * (run + 1);

	// Used from the hub menu to give the player a power up of their choice.
	public static void ActivatePowerUp (string name)
	{
		switch (name) {
		case "run":
			run++;
			break;
		case "doubleJump":
			doubleJump++;
			break;
		case "bonusHealth":
			bonusHealth++;
			break;
		}
	}
	public static void UpdatePrices()
	{
		healthPrice = 500 * (bonusHealth + 1);
		jumpPrice = 1000 * (doubleJump + 1);
		runPrice = 1000 * (run + 1);
	}
}
