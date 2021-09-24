using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bestScore : MonoBehaviour {

	void Update () {
		GetComponent <Text> ().text = "BEST SCORE: " + PlayerPrefs.GetInt ("bestScore");
	}
}
