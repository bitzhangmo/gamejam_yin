using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyDestory : MonoBehaviour
{
    [SerializeField]
    private int bounceTime;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Ground")
        //{
        //    bounceTime--;
        //    if (bounceTime <= 0)
        //    {
        //        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().SendMessage("SubLightFly");
        //        Debug.Log("2");
        //        Destroy(gameObject);
        //    }
        //}
        //else if (collision.gameObject.tag == "Destroy" )
        //{
        //    if (gameObject.tag != "PreLight")
        //    {
        //        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().SendMessage("SubLightFly");
        //        Debug.Log("3");
        //        Debug.Log("Destroy!");
        //        Destroy(gameObject);
        //    }
        //    else
        //    {
        //        Destroy(gameObject);
        //    }
        //}
        if (collision.gameObject.tag != "Reflect")
        {
            if (gameObject.tag != "PreLight")
            {
                GameObject.FindWithTag("GameManager").GetComponent<GameManager>().SendMessage("SubLightFly");
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
