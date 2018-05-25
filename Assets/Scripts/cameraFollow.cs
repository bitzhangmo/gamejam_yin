// 创建标识: zhangMo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {
	public Transform player;
	public Vector3 Margin;
	public Vector3 smoothing;
	//public BoxCollider2D Bounds;

	public float xOffset;
	public float yOffset;
	private Vector3 _min;
	private Vector3 _max;

	[SerializeField] protected float followSpeed;
	public bool isFollowing{get;set;}
	public bool isSmoothFollow;
	void Start()
	{
		isFollowing=true;
		//isSmoothFollow=true;
	}

	protected void Update()
	{
		float xTarget=player.position.x+xOffset;
		float yTarget=player.position.y+yOffset;
		if(isSmoothFollow)
		{
			float xNew=Mathf.Lerp(transform.position.x,xTarget,Time.deltaTime*followSpeed);
			//float yNew=Mathf.Lerp(transform.position.y,yTarget,Time.deltaTime*followSpeed);
			float yNew=0.0f;
			transform.position=new Vector3(xNew,yNew,transform.position.z);
		}
		else
		{
			    transform.position = new Vector3(player.position.x,
         0, transform.position.z);
		}
	
		
	}
}
