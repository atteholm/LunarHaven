using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

	// Loads a scene, identified by its name
	public static void StringManager (string level)
	{
		SceneManager.LoadScene (level);
		Score.startScore = Score.score;

	}

	// Loads a scene, identified by its index
	public static void IndexManager (int sceneNumber)
	{
		SceneManager.LoadScene (sceneNumber);
		Score.startScore = Score.score;

	}

	// Restarts the current level and resets the player score
	public static void Restart ()
	{
		Score.score = Score.startScore;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

}
