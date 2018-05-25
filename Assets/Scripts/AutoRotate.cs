using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [SerializeField]
    private float horizontalSpeed = 1;
    [SerializeField]
    private float verticalSpeed = 1;
    [SerializeField]
    private float yLimit;
    [SerializeField]
    private float xLimit;
    [SerializeField]
    private float zLimit;
    private float xStart;
    private float yStart;
    private float zStart;
    private Rigidbody rb;

    private void Start()
    {
        xStart = transform.position.x;
        yStart = transform.position.y;
        zStart = transform.position.z;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(horizontalSpeed, verticalSpeed, horizontalSpeed);
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.y - yStart) >= yLimit)
        {
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z);
            yStart = transform.position.y;
        }
        if (Mathf.Abs(transform.position.x - xStart) >= xLimit)
        {
            rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, rb.velocity.z);
            xStart = transform.position.x;
        }
        if (Mathf.Abs(transform.position.z - zStart) >= zLimit)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -rb.velocity.z);
            zStart = transform.position.z;
        }
        Debug.Log(rb.velocity);
    }
}
