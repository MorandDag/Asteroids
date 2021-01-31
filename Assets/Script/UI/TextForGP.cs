using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextForGP : MonoBehaviour
{
    public static float textGP;
    public static float pointForPlusHP;

    void Update()
    {
        Text text = GetComponent<Text>();
        text.text = textGP.ToString();

        
    }
}
