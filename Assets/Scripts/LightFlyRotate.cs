using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlyRotate : MonoBehaviour
{
    [SerializeField]
    private int rotateFlyNum;
    [SerializeField]
    private float initDely;
    public GameObject lightFly;
    public Transform initPoint;

    private void Start()
    {
        StartCoroutine(InitFly());
    }

    private IEnumerator InitFly()
    {
        for (int i = 0; i < rotateFlyNum; i++)
        {
            GameObject.Instantiate(lightFly, initPoint.position, initPoint.rotation);
            yield return new WaitForSeconds(initDely);
        }
    }

    public void ReInitFly()
    {
        StartCoroutine(InitFly());
    }
}
