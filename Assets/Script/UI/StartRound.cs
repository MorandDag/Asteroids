using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRound : MonoBehaviour
{
    public GameObject panelQuit;

    public GameObject[] asteroids;
    public Transform startPointAsteroids, spaceForBullets, spaceForUFO;
    public int countAsteroids;

    public GameObject spaceship;
    public Transform Game;

    public GameObject ufoBig;
    float timeCreatUFO = 15;

    void Start()
    {
        CreateAsteroids();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelQuit.SetActive(true);
            panelQuit.GetComponent<PanelQuit>().PauseGame(true);
        }
            

        if (timeCreatUFO <= 0)
        {
            CreateUFO();
            timeCreatUFO = Random.Range(20, 35);
        }
        else
        {
            timeCreatUFO -= Time.deltaTime;
        }

        if (startPointAsteroids.transform.childCount == 0)
            NextRound();
    }

    void CreateAsteroids()
    {
        for(int i = 0; i<countAsteroids; i++)
        {
            int numAsteroid = Random.Range(0, 2);

            float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            Vector3 randomPosition = new Vector3(spawnX, spawnY, 0);
                       
            GameObject asteroid = Instantiate(asteroids[numAsteroid], randomPosition, transform.rotation) as GameObject;
            asteroid.transform.parent = startPointAsteroids;
            asteroid.GetComponent<Asteroids>().spaceForAsteroid = startPointAsteroids.gameObject;
        }
    }

    void CreateUFO()
    {
        float spawnX = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;
        UFOBig.routX = 1;

        if (Random.Range(0, 2) == 1)
        {
            spawnX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
            UFOBig.routX = -1;
        }
        
        float spawnY = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, (Screen.height * 0.35f))).y, Camera.main.ScreenToWorldPoint(new Vector2(0, (Screen.height*0.75f))).y);

        Vector3 randomPosition = new Vector3(spawnX, spawnY, 0);

        GameObject UFO = Instantiate(ufoBig, randomPosition,transform.rotation);
        UFO.transform.parent = spaceForUFO;
        UFO.GetComponent<UFOBig>().spaceForBullet = spaceForBullets;
    }

    public void RestartGame()
    {
        SpaceshipMovement.HP = 3;
        SpaceshipMovement.death = false;
        TextForGP.pointForPlusHP = 0;
        TextForGP.textGP = 0;
        countAsteroids = 4;

        GameObject newSpaceship = Instantiate(spaceship, Vector3.zero, Quaternion.identity) as GameObject;
        newSpaceship.transform.parent = Game;
        newSpaceship.GetComponent<SpaceshipMovement>().spaceForBullet = spaceForBullets;
        CreateAsteroids();
    }

    public void NextRound()
    {
        countAsteroids++;
        CreateAsteroids();
    }
}
