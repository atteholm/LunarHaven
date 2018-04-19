using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour{

	private Button level;

	void Start () {
		level = GameObject.Find ("Button").GetComponent<Button> ();
		level.onClick.AddListener(() => ChangeScene.StringManager ("DesertMap1"));
	}
}
