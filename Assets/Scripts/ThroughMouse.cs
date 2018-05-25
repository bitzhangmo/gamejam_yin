// 创建标识: zhangMo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroughMouse : MonoBehaviour {

	public Vector3 mousePositionInWorld;
	private Vector3 offset;
	public Collider2D player;
	public Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () {
		//Physics.IgnoreCollision(player,this.collider);

	}
	private void OnGUI()
	{
		Event e=Event.current;
		
		mousePositionInWorld=Camera.main.ScreenToWorldPoint(e.mousePosition);
		Debug.Log(mousePositionInWorld);
	}
	
	// Update is called once per frame
	void Update () {
		movePicture();
	}

	void movePicture()
	{
		offset=mousePositionInWorld-transform.position;
		if(Mathf.Abs(offset.x)<1.0f)
		{
			if(offset.x>0)
				rigidbody.AddForce(new Vector2(0.5f,0));
			else
				rigidbody.AddForce(new Vector2(-0.5f,0));
		}
		if(Input.GetMouseButtonDown(1))
		{
			Destroy(this.GetComponent<DistanceJoint2D>());
		}
	}

	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag=="Ground")
		{
			Destroy(gameObject.GetComponent<Rigidbody2D>());
			Destroy(gameObject.GetComponent<ThroughMouse>());
		}
	}
}
