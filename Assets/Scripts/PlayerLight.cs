using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LOS;

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
    [SerializeField]
    private float preSpeed = 50;
    [SerializeField]
    private float checkOffset = 0.5f;
    [SerializeField]
    private float destroyTime = 10f;
    private float checkTime = 0;
    private float lightA;
    private Vector3 clickPosition;
    private Vector3 mousePosition;
    private Vector3 lastMousePosition;
    private GameObject pre;
    private bool isShooting;
    private bool isChecking = false;
    //private CircleCollider2D circleTrigger;
	public Vector3 targetDirection;
    public GameObject light_Fly;
    public GameObject pre_light_Fly;
    public Transform player;
    public Transform lightShootPoint;
    public GameManager GM;
    public LOSRadialLight lightLOS;

    private void Start()
    {
        isShooting = false;
        lastMousePosition = Vector3.zero;
        lightA = lightLOS.color.a;
    }

    private void Update ()
    {
		CreateLight();
	}

	private void CreateLight()
	{
		if (Input.GetMouseButtonUp(0) && !isShooting)
		{
            if (pre != null)
            {
                Destroy(pre);
            }
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetDirection = clickPosition - transform.position;
            lastMousePosition = Vector3.zero;
            Debug.Log("Shoot");
            StartCoroutine(CreateLightWay());
		}
        if (Input.GetMouseButton(0) && !isShooting)
        {
            Debug.Log("Down");
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(Vector3.Magnitude(mousePosition - lastMousePosition));
            if (Vector3.Magnitude(mousePosition - lastMousePosition) <= checkOffset)
            {
                checkTime += Time.deltaTime;
                //Debug.Log(checkTime);
                if (checkTime >= 0.5f && LightNum > 0)
                {
                    if (pre == null)
                    {
                        DrawLine();
                        checkTime = 0;
                    }
                }
            }
            else
            {
                if (pre != null)
                {
                    Destroy(pre);
                }
            }
            lastMousePosition = mousePosition;
        }
	}

    private void DrawLine()
    {
        Vector3 direction = mousePosition - transform.position;
        pre = GameObject.Instantiate(pre_light_Fly, lightShootPoint.position + Vector3.Normalize(direction) * offset, transform.rotation);
        pre.GetComponent<Rigidbody2D>().AddForce(direction * preSpeed);
        Destroy(pre, destroyTime);
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
            lightLOS.color = new Color(lightLOS.color.r, lightLOS.color.g, lightLOS.color.b, lightLOS.color.a - lightA / lightNum);
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
            lightLOS.color = new Color(lightLOS.color.r, lightLOS.color.g, lightLOS.color.b, lightLOS.color.a + lightA / lightNum);
            //Debug.Log("1");
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
