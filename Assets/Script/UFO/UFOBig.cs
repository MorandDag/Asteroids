using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBig : MonoBehaviour
{
    public static float routX = 1;
    public float speed;
    public float lifeTime;
    private float timeShot;
    public float startTimeShot;

    public GameObject bullet;
    public Transform[] shotPoint;
    public Transform spaceForBullet;


    void FixedUpdate()
    {
        //Movement
        transform.Translate(new Vector2(routX * speed * Time.deltaTime,0));
    }

    private void Update()
    {
        if (lifeTime <= 0)
            Destroy(gameObject);
        else
            lifeTime -= Time.deltaTime;

        //Fire
        if (timeShot <= 0)
        {
            //Two guns, not one
            if (Random.Range(0, 2) == 1)
            {
                float randomRotationZ = Random.Range(-90, 90);
                GameObject newBullet = Instantiate(bullet, shotPoint[0].position, Quaternion.Euler(0, 0, randomRotationZ)) as GameObject;
                newBullet.transform.parent = spaceForBullet;
                newBullet.GetComponent<Bullet>().shooter = gameObject;
            }
            else
            {
                float randomRotationZ = Random.Range(90, 180);
                GameObject newBullet = Instantiate(bullet, shotPoint[1].position, Quaternion.Euler(0, 0, randomRotationZ)) as GameObject;
                newBullet.transform.parent = spaceForBullet;
                newBullet.GetComponent<Bullet>().shooter = gameObject;
            }
                

            timeShot = startTimeShot;
        }
        else
            timeShot -= Time.deltaTime;
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
        }
    }

    void OnDisable()
    {
        FindObjectOfType<AudioManager>().Play("UFODeath");

        foreach (Transform child in spaceForBullet)
        {
            if (child.gameObject.GetComponent<Bullet>().shooter.tag == "UFOBig")
                Destroy(child.gameObject);
        }
    }
}
