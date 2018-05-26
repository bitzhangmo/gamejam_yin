// 创建标识: zhangMo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirection : MonoBehaviour {

	[HideInInspector]
	public bool isToMove;
	public float length=5.0f;
	public float moveSpeed=1.0f;
	public enum WhichDirection
	{
		up,
		down,
		left,
		right,
		up_left,
		up_right,
		down_left,
		down_right,
	};

	[SerializeField]private WhichDirection direction;
	private float checkLength=0;
	void Start () {
		isToMove=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(isToMove)
		{
			MoveToTarget(length);
		}
			
	}

	void MoveToTarget(float length)
	{
		switch(direction)
		{
			case WhichDirection.up:
				transform.position=Vector3.MoveTowards(transform.position,transform.position+Vector3.up*length,Time.deltaTime*moveSpeed);break;
			case WhichDirection.down:
				transform.position=Vector3.MoveTowards(transform.position,transform.position+Vector3.down*length,Time.deltaTime*moveSpeed);break;
			case WhichDirection.left:
				transform.position=Vector3.MoveTowards(transform.position,transform.position+Vector3.left*length,Time.deltaTime*moveSpeed);break;
			case WhichDirection.right:
				transform.position=Vector3.MoveTowards(transform.position,transform.position+Vector3.right*length,Time.deltaTime*moveSpeed);break;
			case WhichDirection.up_left:
				transform.position=Vector3.MoveTowards(transform.position,transform.position+Vector3.Normalize(Vector3.up+Vector3.left)*length,Time.deltaTime*moveSpeed);break;
			case WhichDirection.up_right:
				transform.position=Vector3.MoveTowards(transform.position,transform.position+Vector3.Normalize(Vector3.up+Vector3.right)*length,Time.deltaTime*moveSpeed);break;
			case WhichDirection.down_left:
				transform.position=Vector3.MoveTowards(transform.position,transform.position+Vector3.Normalize(Vector3.down+Vector3.left)*length,Time.deltaTime*moveSpeed);break;
			case WhichDirection.down_right:
				transform.position=Vector3.MoveTowards(transform.position,transform.position+Vector3.Normalize(Vector3.down+Vector3.right)*length,Time.deltaTime*moveSpeed);break;
		}
		checkLength+=Time.deltaTime*moveSpeed;
		if(checkLength>=length)
			isToMove=false;
	}
}
