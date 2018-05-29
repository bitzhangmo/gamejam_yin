using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreformManager : MonoBehaviour {

	public GetUpAndDown[] platforms=new GetUpAndDown[11];
	public float sleepSecond;
	private void Update() {
		if(platforms[0].isYourTurn&&platforms[1])
			{
				platforms[0].getUp();
				platforms[1].getUp();
				//StartCoroutine(waitForASeconds());
				if(platforms[0].isReadyToDown&&platforms[1].isReadyToDown)
				{
					platforms[0].getDown();
					platforms[1].getDown();
				}
			}
	}

	IEnumerator waitForASeconds()
	{
		yield return new WaitForSeconds(sleepSecond);
	}
}
