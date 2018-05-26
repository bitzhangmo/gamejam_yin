using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivLight : MonoBehaviour
{
    public PlayerLight pLight;
    private int reflectCount;
    private int enterCount;

    private void Start()
    {
        reflectCount = pLight.LightNum / 2;
        enterCount = pLight.LightNum - reflectCount;
        Debug.Log(reflectCount);
        Debug.Log(enterCount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            reflectCount--;
            if (reflectCount / 2 <= 0)
            {
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            enterCount--;
            if (enterCount <= 0)
            {
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }
    }
}
