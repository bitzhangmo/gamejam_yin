using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyDestory : MonoBehaviour
{
    [SerializeField]
    private int bounceTime;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Reflect")
        {
            GameObject.FindWithTag("GameManager").GetComponent<GameManager>().SendMessage("SubLightFly");
            Debug.Log("SubLightFly");
            Destroy(gameObject);
        }
    }
}
