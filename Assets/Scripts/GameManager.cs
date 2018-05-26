using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int existLightFly = 0;
    public PlayerLight pLightNum;
    public PlayerMove pMove;

    private void Update()
    {
        Debug.Log(existLightFly + pLightNum.LightNum);
        if ((existLightFly + pLightNum.LightNum) <= 0)
        {
            pMove.isDead = true;
        }
    }

    public void AddLightFly()
    {
        existLightFly++;
    }

    public void SubLightFly()
    {
        existLightFly--;
    }
}
