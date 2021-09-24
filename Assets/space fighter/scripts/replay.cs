using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class replay : MonoBehaviour
{
    public void replayGame()
    {
        GameObject.Find("buttonClick").GetComponent<AudioSource>().Play();
        if (GameObject.Find("game").transform.Find("score") != null)
        {
            GameObject.Find("game").transform.Find("score").GetComponent<Text>().text = "SCORE: 0";
            GameObject.Find("game").transform.Find("playersHealth").GetComponent<Text>().text = "HEALTH: 100%";
        }

        Vars.score = 0;
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < enemys.Length; i++)
        {
            Destroy(enemys[i]);
        }

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i]);
        }

        GameObject[] stars = GameObject.FindGameObjectsWithTag("star");
        for (int i = 0; i < stars.Length; i++)
        {
            Destroy(stars[i]);
        }

        GameObject.Find("Canvas").GetComponent<gameover>().gameoverButton();

        if (GameObject.Find("playerSpacecraft(Clone)") == null)
        {
            GameObject g = Instantiate(Resources.Load("playerSpacecraft"),
                new Vector2(0, 0), Quaternion.identity) as GameObject;
        }

        if (GameObject.Find("playerSpacecraft") != null)
        {
            Destroy(GameObject.Find("playerSpacecraft"));
        }

        Vars.level = 1;
        if (GameObject.Find("playerSpacecraft(Clone)") != null)
        {
            GameObject.Find("playerSpacecraft(Clone)").GetComponent<collisionWithEnemy>().calculateSpacecraftHealth();
            GameObject.Find("camera").GetComponent<smoothCamera2D>().newTarget();
            GameObject.Find(("playerSpacecraft(Clone)")).GetComponent<bl_ControllerExample>().enabled = true;
            GameObject.Find(("Enemy")).GetComponent<EnemySpawn>().enabled = true;
        }

        Vars.gameover = false;
    }

    public void replayGameFromPauseMenu()
    {
        Vars.gameover = false;
        if (GameObject.Find("game").transform.Find("score") != null)
        {
            GameObject.Find("game").transform.Find("score").GetComponent<Text>().text = "SCORE: 0";
        }

        Vars.score = 0;
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("enemy");
        for (int i = 0; i < enemys.Length; i++)
        {
            Destroy(enemys[i]);
        }

        GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i]);
        }

        GameObject[] stars = GameObject.FindGameObjectsWithTag("star");
        for (int i = 0; i < stars.Length; i++)
        {
            Destroy(stars[i]);
        }

        if (GameObject.Find("playerSpacecraft(Clone)") != null)
        {
            GameObject.Find("playerSpacecraft(Clone)").GetComponent<collisionWithEnemy>().calculateSpacecraftHealth();
            GameObject.Find(("playerSpacecraft(Clone)")).GetComponent<bl_ControllerExample>().enabled = true;
            GameObject.Find("playerSpacecraft(Clone)").transform.position = new Vector2(0, 0);
            GameObject.Find(("Enemy")).GetComponent<EnemySpawn>().enabled = true;
        }

        Vars.level = 1;
    }
}