using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    [SerializeField]
    private float LightLength;
    [SerializeField]
    private float initWaitTime;
    [SerializeField]
    private float speed;
	private Vector3 clickPosition;
    private int lightNum;
	public Vector3 targetDirection;
    public GameObject lightPoint;
    public Transform player;
    public Transform lightShootPoint;

	private void Update ()
    {
		CreateLight();
	}

	private void CreateLight()
	{
		if (Input.GetMouseButtonUp(0))
		{
            lightNum -= 1;
			clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetDirection=new Vector3(clickPosition.x-player.transform.position.x,clickPosition.y-player.transform.position.y,player.transform.position.z);
            Debug.Log("Shoot");
            CreateLightWay();
		}
	}

    private void CreateLightWay()
    {
        GameObject point;
        point = GameObject.Instantiate(lightPoint, lightShootPoint.position, transform.rotation);
        point.GetComponent<Rigidbody2D>().AddForce(targetDirection * speed);
    }
}
