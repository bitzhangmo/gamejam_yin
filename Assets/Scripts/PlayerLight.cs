using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    [SerializeField]
    private float initWaitTime;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int lightNum;
    [SerializeField]
    private float offset;
	private Vector3 clickPosition;
    private bool isShooting;
    //private CircleCollider2D circleTrigger;
	public Vector3 targetDirection;
    public GameObject light_Fly;
    public Transform player;
    public Transform lightShootPoint;
    public GameManager GM;

    private void Start()
    {
        isShooting = false;
    }

    private void Update ()
    {
		CreateLight();
	}

	private void CreateLight()
	{
		if (Input.GetMouseButtonUp(0) && !isShooting)
		{
			clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetDirection=new Vector3(clickPosition.x-player.transform.position.x,clickPosition.y-player.transform.position.y,player.transform.position.z);
            Debug.Log("Shoot");
            StartCoroutine(CreateLightWay());
		}
	}

    private IEnumerator CreateLightWay()
    {
        GameObject point;
        isShooting = true;
        gameObject.GetComponent<PlayerMove>().isShooting = true;
        for (;lightNum > 0; lightNum--)
        {
            point = GameObject.Instantiate(light_Fly, lightShootPoint.position + Vector3.Normalize(targetDirection) * offset, transform.rotation);
            point.GetComponent<Rigidbody2D>().AddForce(targetDirection * speed);
            GM.SendMessage("AddLightFly");
            yield return new WaitForSeconds(initWaitTime);
        }
        this.gameObject.GetComponent<PlayerMove>().isShooting = false;
        isShooting = false;
        //circleTrigger.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Light")
        {
            lightNum++;
            GM.SendMessage("SubLightFly");
            Destroy(collision.gameObject);
        }
    }

    public int LightNum
    {
        get
        {
            return lightNum;
        }
    }
}
