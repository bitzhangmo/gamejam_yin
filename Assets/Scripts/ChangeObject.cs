using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject : MonoBehaviour
{
    [SerializeField]
    private float offset;
    [SerializeField]
    private float shakeTimes;
    [SerializeField]
    private float changeSpeed;
    [SerializeField]
    private float speed;
    private Vector3 originalPosition;
    private static Vector3 bigScale = new Vector3(1, 1, 1);
    private static Vector3 smallScale = new Vector3(0.5f, 0.5f, 0.5f);
    public Transform targetPosition;
    public bool isBigger = false;
    public bool isSmaller = false;
    public bool isFalling = false;
    public bool isShaking = false;
    public bool isStart = false;

    private void Start()
    {
        originalPosition = transform.position; 
    }

    private IEnumerator ShakeObject()
    {
        for (int i = 0; i < shakeTimes; i++)
        {
            Vector3 randomVector = new Vector3(Random.Range(-offset, offset), Random.Range(-offset, offset), 0);
            transform.position += randomVector;
            yield return null;
        }
        transform.position = originalPosition;
        isShaking = false;
    }

    private void Update()
    {
        if (isStart)
        {
            if (isShaking)
            {
                StartCoroutine(ShakeObject());
            }
            if (isBigger)
            {
                BeBigger();
            }
            if (isSmaller)
            {
                BeSmaller();
            }
            if (isFalling)
            {
                FallingDown();
            }
        }
    }
    
    private IEnumerator ObjectMove()
    {
        if (isShaking)
        {
            StartCoroutine(ShakeObject());
        }
        yield return new WaitForSeconds(0.5f);
        if (isBigger)
        {
            BeBigger();
        }
        yield return new WaitForSeconds(0.5f);
        if (isSmaller)
        {
            BeSmaller();
        }
        yield return new WaitForSeconds(0.5f);
        if (isFalling)
        {
            FallingDown();
        }
    }

    private void BeBigger()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, bigScale, changeSpeed * Time.deltaTime);
        if (Vector3.Magnitude(transform.localScale - bigScale) <= 0.1)
        {
            Debug.Log("Big");
            transform.localScale = bigScale;
            isBigger = false;
        }
    }

    private void BeSmaller()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetPosition.position, changeSpeed * Time.deltaTime);
        if (Vector3.Magnitude(transform.localScale - smallScale) <= 0.1)
        {
            Debug.Log("Small");
            transform.localScale = smallScale;
            isSmaller = false;
        }
    }

    private void FallingDown()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition.position, Time.deltaTime * speed);
        if (Vector3.Magnitude(transform.position - targetPosition.position) < 0.1f )
        {
            transform.position = targetPosition.position;
            isFalling = false;
        }
    }
}
