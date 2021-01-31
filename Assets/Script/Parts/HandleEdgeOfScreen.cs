using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleEdgeOfScreen : MonoBehaviour
{
    void Update()
    {
        if (gameObject.transform.position.x > Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x + gameObject.transform.localScale.x)
        {
            gameObject.transform.position = new Vector2(-Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x < -Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x - gameObject.transform.localScale.x)
        {
            gameObject.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x,  gameObject.transform.position.y);
        }

        if (gameObject.transform.position.y > Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y + gameObject.transform.localScale.y)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, -Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        }
        else if (gameObject.transform.position.y < -Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y - gameObject.transform.localScale.y)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        }
    }
}
