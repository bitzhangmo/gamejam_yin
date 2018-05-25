// 创建标识: zhangMo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	[HideInInspector]
	private Transform p_transform;
	private Rigidbody2D p_rigidbody;

	public float jumpHeight=20f;
	public float moveSpeed=5.0f;
	public bool isGrounded=true;
	
	public Vector3 velocity;
	void Awake()
	{
		p_transform=GetComponent<Transform>();
		p_rigidbody=GetComponent<Rigidbody2D>();
	}
	void Start () {
		Debug.Log(transform.name);
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move()
	{
		if(Input.GetKeyDown(KeyCode.Space)&&isGrounded)
		{
			//transform.Translate(Vector3.up*30.0f*Time.deltaTime);
			p_rigidbody.AddForce(new Vector3(0,jumpHeight,0));
			Debug.Log("W");
		}
		else if(Input.GetKey(KeyCode.A))
		{
			p_transform.Translate(Vector3.left*10.0f*Time.deltaTime);
			//rigidbody.AddForce(new Vector3(-moveSpeed,0,0));
			Debug.Log("A");
		}
		/*else if(Input.GetKeyDown(KeyCode.S))
		{
			//transform.Translate(Vector3.down*10.0f*Time.deltaTime);
			//rigidbody.AddForce(new Vector3(0,-10,0));
			Debug.Log("S");
		}*/
		else if(Input.GetKey(KeyCode.D))
		{
			p_transform.Translate(Vector3.right*10.0f*Time.deltaTime);
			//rigidbody.AddForce(new Vector3(moveSpeed,0,0));
			Debug.Log("D");
		}
	}
}
