using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public static int HP = 3;
    public static bool death = false;

    public GameObject bullet;
    public Transform shotPoint, spaceForBullet;
    public Rigidbody2D rb;

    private float timeShot;
    public float startTimeShot;

    public float runSpeed = 5f, turnSpeed = 40f;

    private void FixedUpdate()
    {
        //Movement
        if (Input.GetAxis("Vertical") > 0)
            rb.AddRelativeForce(Vector2.up * runSpeed);
        if (Input.GetAxis("Horizontal") > 0)
            rb.rotation += -turnSpeed * Time.deltaTime;
        if (Input.GetAxis("Horizontal") < 0)
            rb.rotation += turnSpeed * Time.deltaTime;
    }

    void Update()
    {
        if (timeShot <= 0)
        {
            //hyperjump
            if (Input.GetKey(KeyCode.Space))
            {
                float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                float spawnX = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

                transform.position = new Vector3(spawnX, spawnY,0);

                timeShot = startTimeShot;
            }

            //Fire
            if (Input.GetButton("Fire1"))
            {
                GameObject newBullet = Instantiate(bullet, shotPoint.position, transform.rotation) as GameObject;
                newBullet.transform.parent = spaceForBullet;
                newBullet.GetComponent<Bullet>().shooter = gameObject;

                timeShot = startTimeShot;
            }
            }
        else
            timeShot -= Time.deltaTime;
    }

    void OnDisable()
    {
        HP -= 1;
        death = true;

        foreach (Transform child in spaceForBullet)
        {
            if(child.gameObject.GetComponent<Bullet>().shooter.tag == "Player")
                Destroy(child.gameObject);
        }
    }
}
