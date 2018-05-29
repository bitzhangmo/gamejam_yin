
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUpAndDown : MonoBehaviour {

	public float speed;
	public bool isYourTurn=false;
	public bool isReadyToDown=false;
	public void getUp()
	{
		if(transform.rotation.x>0&&transform.rotation.x<90)
			transform.Rotate(new Vector3(-Time.deltaTime*speed,0,0));
		else if(transform.rotation.x<0) isReadyToDown=true;
		else if(transform.rotation.x>90) isYourTurn=false;
			
	}

	public void getDown()
	{
		if(transform.rotation.x<0&&transform.rotation.x>-90)
			transform.Rotate(new Vector3(-Time.deltaTime*speed,0,0));
		else if(transform.rotation.x>=0)
		{
			isReadyToDown=false;
			isYourTurn=false;
		} 
		//else if(transform.rotation.x>90) isYourTurn=false;

	}
}
