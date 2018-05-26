// 创建标识: zhangMo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateReflect : MonoBehaviour {

	private float rotateTimer=0;
	public float rotateSpeed=1;
	public float rotateAngel=60;
	public bool isRotate=false;
	public bool isJustThreeTimes=false;
	public int checkNum=3;
	public int command=3;
	private void Update() {
		if(isJustThreeTimes)
		{
			if(isRotate)
			{
				if(checkNum<=0)return;
				ReflectRotate(command);
			}
		}
		else
		{
			if(isRotate)
			{
				ReflectRotate(command);
			}
		}
	}
	void ReflectRotate(int command)
	{	
		if(command==2&&rotateTimer<rotateAngel)
		{
			rotateTimer+=Time.deltaTime*rotateSpeed;
			gameObject.transform.Rotate(0,0,-Time.deltaTime*rotateSpeed);
		}
		if(command==0&&rotateTimer<rotateAngel)
		{
			rotateTimer+=Time.deltaTime*rotateSpeed;
			gameObject.transform.Rotate(0,0,Time.deltaTime*rotateSpeed);
		}
		if(command==1&&rotateTimer<rotateAngel)
		{
			rotateTimer+=Time.deltaTime*rotateSpeed;
			gameObject.transform.Rotate(0,0,Time.deltaTime*rotateSpeed);
		}
		if(command==3){}
		if(rotateTimer>rotateAngel)
		{
			rotateTimer=0;
			checkNum--;
			isRotate=false;
		}
	}
	void setCommand(int cmd)
	{
		command=cmd;
	}
}
