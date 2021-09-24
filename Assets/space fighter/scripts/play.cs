using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class play : MonoBehaviour {

	float timer = 0;
	float fade = 0;
	bool changeScene = false;
	bool gp = false;
	public GameObject image;
	public GameObject mainMenu;
	public GameObject gameUI;
	public static bool playing;
	Image im;

	void Start () {
		im = image.GetComponent <Image> ();
	}
	void Update () {
		if (gp) {
			timer += Time.deltaTime;
			if (timer >= 0.02f) {
				timer = 0;
				if (changeScene == false) {
					fade += 0.1f;
					if (fade >= 1.5f) {
						
						mainMenu.SetActive (false);
						gameUI.SetActive (true);
						GameObject.Find("Enemy").GetComponent <EnemySpawn> ().enabled = true;
						GameObject.Find ("playerSpacecraft(Clone)").GetComponent <bl_ControllerExample> ().enabled = true;
						changeScene = true;
						if (GameObject.Find ("playerSpacecraft(Clone)") != null) {
							GameObject.Find ("playerSpacecraft(Clone)").GetComponent<collisionWithEnemy> ().playerHealth = 100;
						}
						if (GameObject.Find ("game").transform.Find ("score") != null) {
							GameObject.Find ("game").transform.Find ("score").GetComponent <Text> ().text = "SCORE: 0";
						}
					}
				} else {
					
					fade -= 0.1f;
					if (fade <= 0f) {
						if (PlayerPrefs.GetInt ("music") == 0) {
							
						}
						gp = false;
						fade = 0;
						changeScene = false;
					}
				}
				if (PlayerPrefs.GetInt ("music") == 1) {
				}
				im.color = new Color (0, 0, 0, fade);
			}
		}
	}

	public void playGame ()
	{
		if (GameObject.Find("playerSpacecraft(Clone)") == null)
		{
			GameObject g = Instantiate(Resources.Load("playerSpacecraft"),
				new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		}

		if (GameObject.Find("playerSpacecraft") != null)
		{
			Destroy(GameObject.Find("playerSpacecraft"));
		}

		GameObject.Find ("buttonClick").GetComponent<AudioSource> ().Play ();
		Vars.score = 0;
		GameObject.Find ("camera").GetComponent<smoothCamera2D> ().newTarget ();
		gp = true; 
		playing = true;
		GameObject.Find ("Canvas").GetComponent<sound> ().checkMusic ();
		GameObject.Find ("Canvas").GetComponent<sound> ().checkSound ();
		Vars.gameover = false;
	}
}
