using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPileScript : MonoBehaviour
{

	public GameObject goldPile;
	float x = Mathf.PI / 100;

	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3 (transform.position.x, (float)(transform.position.y + (Mathf.Sin (x)) / 100), transform.position.z);
		x += Mathf.PI / 100;
		if (x >= Mathf.PI) {
			x += Mathf.PI / 100;
		}
	}
}
