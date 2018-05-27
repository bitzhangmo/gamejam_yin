using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurtainMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public Transform target_1;
    public Transform target_2;
    public Transform curtain_1;
    public Transform curtain_2;
    public bool isOver = false;

    private void Update()
    {
        if (isOver)
        {
            Move();
        }
    }

    private void Move()
    {
        curtain_1.position = Vector3.Lerp(curtain_1.position, target_1.position, Time.deltaTime * speed);
        curtain_2.position = Vector3.Lerp(curtain_2.position, target_2.position, Time.deltaTime * speed);
        if (Vector3.Magnitude(curtain_1.position - target_1.position) < 1 || Vector3.Magnitude(curtain_2.position - target_2.position) < 1)
        {
            curtain_1.position = target_1.position;
            curtain_2.position = target_2.position;
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            isOver = true;
        }
    }
}