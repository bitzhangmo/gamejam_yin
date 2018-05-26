using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStep : MonoBehaviour {

	int checkedNum=1;
	public RotateReflect rrf;

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="Player")
		{
			checkedNum++;
			rrf.isRotate=true;
			//print(checkedNum%3);
			rrf.SendMessage("setCommand",checkedNum%3);
		}
	}
}
