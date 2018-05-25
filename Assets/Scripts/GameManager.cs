using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int existLightFly = 0;

    public void AddLightFly()
    {
        existLightFly++;
    }

    public void SubLightFly()
    {
        existLightFly--;
    }
}
