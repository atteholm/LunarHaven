/// <summary>
/// Hub menu controller.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HubMenuController : MonoBehaviour
{

	// Fields
	private static Button nextLevel, buyLifeButton, buyJumpButton, buyRunButton, stats;
	private static Text outputText, jumpPriceText, lifePriceText, runPriceText;
	private RectTransform needle;
	public float needleAngle;

	void Start ()
	{
		PowerUps.UpdatePrices ();
		needleAngle = 80 - Score.fuelCans * 53.33f;

		outputText = GameObject.Find ("OutputText").GetComponent<Text> ();
		nextLevel = GameObject.Find ("NextLevelButton").GetComponent<Button> ();
		nextLevel.onClick.AddListener (() => ChangeScene.IndexManager (Score.fuelCans + 1));

		buyLifeButton = GameObject.Find ("BuyLifeButton").GetComponent<Button> ();
		buyLifeButton.onClick.AddListener (() => BuyLife ());

		buyJumpButton = GameObject.Find ("BuyDoubleJumpButton").GetComponent<Button> ();
		buyJumpButton.onClick.AddListener (() => BuyJump ());

		buyRunButton = GameObject.Find ("BuyRunButton").GetComponent<Button> ();
		buyRunButton.onClick.AddListener (() => BuyRun ());

		stats = GameObject.Find ("StatsButton").GetComponent<Button> ();
		stats.onClick.AddListener (() => PrintStats ());

		needle = GameObject.Find ("GasNeedle").GetComponent<RectTransform> ();
		needle.Rotate (new Vector3 (0, 0, needleAngle));

		jumpPriceText = buyJumpButton.GetComponentInChildren<Text> ();
		lifePriceText = buyLifeButton.GetComponentInChildren<Text> ();
		runPriceText = buyRunButton.GetComponentInChildren<Text> ();


	}

	void Update(){
		PowerUps.UpdatePrices ();
		lifePriceText.text = " Buy extra life \t\t" + PowerUps.healthPrice;
		jumpPriceText.text = " Buy extra jump \t" + PowerUps.jumpPrice;
		runPriceText.text = " Upgrade run \t\t" + PowerUps.runPrice;
	}

	// Gives the player and extra life if you can afford it and removes the price from the player's score
	public static void BuyLife ()
	{
		if (Score.score >= PowerUps.healthPrice) {
			Score.score -= PowerUps.healthPrice;
			PowerUps.ActivatePowerUp ("bonusHealth");
			lifePriceText.text = " Buy extra life \t\t" + PowerUps.healthPrice;
			outputText.text = "You received an extra life! You can now take more damage without restarting.";
		} else {
			outputText.text = "You can't afford that!";
		}
	}

	// Gives the ability to double jump if the player has enough money and doesn't already own this power up.
	public static void BuyJump ()
	{
		if (Score.score >= PowerUps.jumpPrice) {
			Score.score -= PowerUps.jumpPrice;
			PowerUps.ActivatePowerUp ("doubleJump");
			jumpPriceText.text = " Buy double jump \t" + PowerUps.jumpPrice;
			outputText.text = "You can now jump " + PowerUps.doubleJump + " times without touching the ground!";
		} else {
			outputText.text = "You can't afford that!";
		}
	}

	// Gives the ability to run if the player has enough money and doesn't already own this power up.
	public static void BuyRun ()
	{
		if (Score.score >= PowerUps.runPrice) {
			Score.score -= PowerUps.runPrice;
			PowerUps.ActivatePowerUp ("run");
			runPriceText.text = " Buy run \t\t\t" + PowerUps.runPrice;
			outputText.text = "You can now run! Hold shift while playing to go faster.";
		} else {
			outputText.text = "You can't afford that!";
		}
	}

	// Shows what power ups the player has, where they are located and other useful information.
	public static void PrintStats ()
	{
		outputText.text = "Fuel cans collected: " + Score.fuelCans
						+ "\nExtra jump level: " + PowerUps.doubleJump
						+ "\nExtra lives: " + PowerUps.bonusHealth
						+ "\nRun level: " + PowerUps.run
						+ "\nLocation: Geatune";
	}
}
