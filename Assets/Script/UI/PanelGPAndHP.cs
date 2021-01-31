using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGPAndHP : MonoBehaviour
{
    public GameObject Game;
    public GameObject GameOver;

    public GameObject[] imageHP;
    public GameObject spaceship;

    public Transform spaceForAsteroid, spaceForBullet, spaceForUFO;

    public float timeRespawn = 3;


    void Update()
    {
        if (SpaceshipMovement.death)
        {
            //GameOver
            if (SpaceshipMovement.HP == 0)
            {
                
                for(int i = 0; i<3; i++)
                {
                    foreach (Transform child in spaceForAsteroid)
                    {
                        Destroy(child.gameObject);
                    }
                }
                foreach (Transform child in spaceForBullet)
                {
                    Destroy(child.gameObject);
                }
                foreach (Transform child in spaceForUFO)
                {
                    Destroy(child.gameObject);
                }

                Game.SetActive(false);
                GameOver.SetActive(true);
            }
            else if(timeRespawn > 0)
            {
                timeRespawn -= Time.deltaTime;
            }
            //Respawn Spaceship
            else if ((timeRespawn <= 0) && (SpaceshipMovement.HP != 0))
            {
                if (timeRespawn <= 0)
                {
                    GameObject newSpaceship = Instantiate(spaceship, Vector3.zero, Quaternion.identity) as GameObject;
                    newSpaceship.transform.parent = Game.transform;
                    newSpaceship.GetComponent<SpaceshipMovement>().spaceForBullet = spaceForBullet;
                }
                    
                SpaceshipMovement.death = false;
                timeRespawn = 3;
            }
             
        }

        //HP+
        if ((TextForGP.pointForPlusHP >= 10000) && (SpaceshipMovement.HP < 3))
        {
            SpaceshipMovement.HP++;
            TextForGP.pointForPlusHP = 0;
            Debug.Log("HP++; " + SpaceshipMovement.HP);
        }

        //Controllet icon HP
        switch (SpaceshipMovement.HP)
        {
            case 3:
                imageHP[2].SetActive(true);
                imageHP[1].SetActive(true);
                imageHP[0].SetActive(true);
                break;
            case 2:
                imageHP[2].SetActive(false);
                imageHP[1].SetActive(true);
                imageHP[0].SetActive(true);
                break;
            case 1:
                imageHP[1].SetActive(false);
                imageHP[0].SetActive(true);
                break;
            case 0:
                imageHP[0].SetActive(false);
                break;
        }
    }
}
