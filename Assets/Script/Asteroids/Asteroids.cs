using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public GameObject[] asteroids; //6
    public float speed;
    public int sizeAsteroid;

    public GameObject spaceForAsteroid;

    private float randomRotationZ;

    private void Start()
    {
        if(sizeAsteroid == 3)
        {
            randomRotationZ = Random.Range(0, 359);
            transform.Rotate(0, 0, randomRotationZ);
        }
        
    }
    void FixedUpdate()
    {
        //Movement
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.tag == "Player") || (col.gameObject.tag == "UFOBig"))
        {
            Destroy(col.gameObject);
        }
    }

    void OnDisable()
    {
        //Create 2 child asteroids
        if((sizeAsteroid == 3) || (sizeAsteroid == 2))
        {
            var numAsteroid = Random.Range(0,3);
            
            randomRotationZ = Random.Range(0, 359);

            GameObject childAsteroid1 = Instantiate
                (asteroids[numAsteroid], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, 0, randomRotationZ)) as GameObject;
            childAsteroid1.transform.parent = spaceForAsteroid.transform;
            childAsteroid1.GetComponent<Asteroids>().spaceForAsteroid = spaceForAsteroid;

            randomRotationZ = Random.Range(0, 359);

            GameObject childAsteroid2 = Instantiate
                (asteroids[numAsteroid], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.Euler(0, 0, randomRotationZ)) as GameObject;
            childAsteroid2.transform.parent = spaceForAsteroid.transform;
            childAsteroid2.GetComponent<Asteroids>().spaceForAsteroid = spaceForAsteroid;
        }
        
    }
}
