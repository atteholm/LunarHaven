﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	
	public static void StringManager(string level) {
		SceneManager.LoadScene (level);
		Score.startScore = Score.score;

	}

	public static void Restart (){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

}
