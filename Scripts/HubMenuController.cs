/// <summary>
/// Hub menu controller.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HubMenuController : MonoBehaviour {

	// Fields
	private Button nextLevel, buyLife, buyJump, buyRun, stats;
	private static Text outputText;

	void Start () {
		outputText = GameObject.Find ("OutputText").GetComponent<Text> ();
		nextLevel = GameObject.Find ("NextLevelButton").GetComponent<Button> ();
		nextLevel.onClick.AddListener(() => ChangeScene.StringManager ("DesertMap1"));

		buyLife = GameObject.Find ("BuyLifeButton").GetComponent<Button> ();
		buyLife.onClick.AddListener(() => BuyLife());

		buyJump = GameObject.Find ("BuyDoubleJumpButton").GetComponent<Button> ();
		buyJump.onClick.AddListener(() => BuyJump());

		buyRun = GameObject.Find ("BuyRunButton").GetComponent<Button> ();
		buyRun.onClick.AddListener(() => BuyRun());

		stats = GameObject.Find ("StatsButton").GetComponent<Button> ();
		stats.onClick.AddListener(() => PrintStats());
	}

	// Gives the player and extra life if you can afford it and removes the price from the player's score
	public static void BuyLife(){
		if (Score.score >= 300) {
			PowerUps.bonusHealth++;
			Score.score -= 300;
			outputText.text = "You received an extra life! You can now take more damage without restarting.";
		} else {
			outputText.text = "You can't afford that!";
		}
	}

	// Gives the ability to double jump if the player has enough money and doesn't already own this power up.
	public static void BuyJump(){
		if (PowerUps.doubleJump == false && Score.score >= 1200) {
			PowerUps.doubleJump = true;
			Score.score -= 1200;
			outputText.text = "You can now double jump!";
		} else if (PowerUps.doubleJump == true) {
			outputText.text = "You already own that power up.";
		} else {
			outputText.text = "You can't afford that!";
		}
	}

	// Gives the ability to run if the player has enough money and doesn't already own this power up.
	public static void BuyRun(){
		if (PowerUps.run == false && Score.score >= 1000) {
			PowerUps.run = true;
			Score.score -= 1000;
			outputText.text = "You can now run! Hold shift while playing to go faster.";
		} else if (PowerUps.run == true) {
			outputText.text = "You already own that power up.";
		} else {
			outputText.text = "You can't afford that!";
		}
	}

	// Shows what power ups the player has, where they are located and other useful information.
	public static void PrintStats(){
		outputText.text = "Stats currently unavailable.";
	}
}
