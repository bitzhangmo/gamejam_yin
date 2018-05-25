// Copyright (C) 2018 武汉艺画开天文化传播有限公司 版权所有
// 创建标识: zhangMo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour {

	public Transform player;
	private Vector3 clickPosition;
	public Vector3 targetDirection;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		createLight();
	}

	public void createLight()
	{
		if(Input.GetMouseButtonUp(0))
		{
			clickPosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//print(clickPosition);
			targetDirection=new Vector3(clickPosition.x-player.transform.position.x,clickPosition.y-player.transform.position.y,player.transform.position.z);
			print(targetDirection);
		}
	}
}
