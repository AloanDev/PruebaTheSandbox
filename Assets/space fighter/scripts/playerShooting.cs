using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour
{
    public static GameObject player;
    private GameObject playerObject;
    private AudioSource shootAudio;
    public float shootingTimer = 0;
    private float timer = 0.3f;
    public Vector3 bulletOffset = new Vector3(0f, 0.5f, 0f);
    public GameObject bulletPrefab;
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    int bulletLayer;

    void Start()
    {
        shootAudio = GameObject.Find("shoot").GetComponent<AudioSource>();
        playerObject = GameObject.Find("gun");

        if (PlayerPrefs.GetInt("fireSpeedLevel") > 1)
        {
            shootingTimer = 0.4f - ((float)PlayerPrefs.GetInt("fireSpeedLevel") / 200);
        }
        else
        {
            shootingTimer = 0.4f;
        }
    }

    void Update()
    {
        if (player && Vars.gameover == false)
        {
            timer += Time.deltaTime;
            if (timer >= shootingTimer)
            {
                timer = 0;
                
                //GameObject bullet = Instantiate(Resources.Load("bullet"),new Vector2(playerObject.transform.position.x, playerObject.transform.position.y),Quaternion.identity) as GameObject;
            }
        }
        else
        {
            player = GameObject.Find("playerSpacecraft(Clone)");
            if (GameObject.Find("playerSpacecraft(Clone)") != null)
            {
                playerObject = GameObject.Find("playerSpacecraft(Clone)").transform.Find("gun").gameObject;

                if (PlayerPrefs.GetInt("fireSpeedLevel") > 1)
                {
                    shootingTimer = 0.4f - ((float)PlayerPrefs.GetInt("fireSpeedLevel") / 200);
                }
                else
                {
                    shootingTimer = 0.4f;
                }
            }
        }
    }

    public void Shoot()
    {
        cooldownTimer -= Time.deltaTime;
        {
            cooldownTimer = fireDelay;
            
            Vector3 offset = transform.rotation * bulletOffset;

            GameObject bulletGO = Instantiate(bulletPrefab, player.transform.localPosition + offset, player.transform.localRotation * Quaternion.Euler(0, 0, Random.Range(-5, 5)));
            bulletGO.layer = bulletLayer;
            shootAudio.Play();
        }
    }
}