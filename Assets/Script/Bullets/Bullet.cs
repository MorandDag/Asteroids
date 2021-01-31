using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public GameObject shooter;

    public float speed;
    public float lifeTime;
    public float distance;
    
    // Update is called once per frame
    void Update()
    {
        //Movement
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (lifeTime <= 0)
            Destroy(gameObject);
        else
            lifeTime -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(shooter.tag == "Player")
        {
            var tagObj = col.gameObject.tag;

            switch (tagObj)
            {
                case "AsteroidBig":
                    TextForGP.textGP += 20;
                    TextForGP.pointForPlusHP += 20;
                    break;
                case "AsteroidMid":
                    TextForGP.textGP += 50;
                    TextForGP.pointForPlusHP += 50;
                    break;
                case "AsteroidLitl":
                    TextForGP.textGP += 100;
                    TextForGP.pointForPlusHP += 100;
                    break;
                case "UFOBig":
                    TextForGP.textGP += 200;
                    TextForGP.pointForPlusHP += 200;
                    break;
            }
        }
        

        Destroy(col.gameObject);
        Destroy(gameObject);
    }
}
