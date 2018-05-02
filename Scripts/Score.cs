/// <summary>
/// Score.
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	
	private static Text points;
	public static int score = 0, startScore = 0, fuelCans = 0;


	public static void GetPoints ()
	{
		score++;
		points.text = "Score: " + score;
	}

	// Use this for initialization
	void Start ()
	{
		points = GameObject.Find ("Score").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		points.text = "Score: " + score;
		if (Input.GetKeyDown (KeyCode.I)) {
			score += 1000;
		}
	}
}
