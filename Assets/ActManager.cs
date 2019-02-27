// 创建标识: zhangMo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActManager : MonoBehaviour {

	public float time;
	public float speed;
	public GameObject[] actions;
	public GetPerformDown[] performers;
	// Use this for initialization
	void Start () {
		StartCoroutine(Action1());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Action1()
	{
		//牌子1，2降
		actions[0].GetComponent<GetPerformDown>().isGoDownSetter();
		actions[1].GetComponent<GetPerformDown>().isGoDownSetter();
		yield return new WaitForSeconds(2.4f);

		//A,B,D,E降
		performers[0].isGoDownSetter();
		performers[1].isGoDownSetter();
		performers[3].isGoDownSetter();
		performers[4].isGoDownSetter();
		yield return new WaitForSeconds(1);

		//牌子1,2收
		for(float i=0;i<time/2;i+=Time.deltaTime)
		{
			actions[0].GetComponent<SpringJoint2D>().connectedAnchor=new Vector2(actions[0].GetComponent<SpringJoint2D>().connectedAnchor.x-Time.deltaTime*speed,actions[0].GetComponent<SpringJoint2D>().connectedAnchor.y);
			actions[1].GetComponent<SpringJoint2D>().connectedAnchor=new Vector2(actions[1].GetComponent<SpringJoint2D>().connectedAnchor.x+Time.deltaTime*speed,actions[1].GetComponent<SpringJoint2D>().connectedAnchor.y);
			if(i>time/10)
				actions[2].GetComponent<GetPerformDown>().isGoDownSetter();
			yield return null;
		}
		actions[0].SetActive(false);
		actions[1].SetActive(false);		
		//牌子3降
		//actions[2].GetComponent<GetPerformDown>().isGoDownSetter();
		//yield return new WaitForSeconds(1);
		//4降
		actions[3].GetComponent<GetPerformDown>().isGoDownSetter();
		yield return new WaitForSeconds(0.5f);
		//5降
		actions[4].GetComponent<GetPerformDown>().isGoDownSetter();
		yield return new WaitForSeconds(0.5f);
		//3,4,5收
		for(float i=0;i<time/4;i+=Time.deltaTime)
		{
			actions[2].GetComponent<SpringJoint2D>().connectedAnchor=new Vector2(actions[2].GetComponent<SpringJoint2D>().connectedAnchor.x-Time.deltaTime*speed,actions[2].GetComponent<SpringJoint2D>().connectedAnchor.y);
			actions[3].GetComponent<SpringJoint2D>().connectedAnchor=new Vector2(actions[3].GetComponent<SpringJoint2D>().connectedAnchor.x+Time.deltaTime*speed,actions[3].GetComponent<SpringJoint2D>().connectedAnchor.y);
			actions[4].GetComponent<SpringJoint2D>().connectedAnchor=new Vector2(actions[4].GetComponent<SpringJoint2D>().connectedAnchor.x+Time.deltaTime*speed,actions[4].GetComponent<SpringJoint2D>().connectedAnchor.y);
			yield return null;
		}
		yield return new WaitForSeconds(1);
		actions[2].SetActive(false);
		actions[3].SetActive(false);
		actions[4].SetActive(false);

		//C降
		performers[2].isGoDownSetter();
		yield return new WaitForSeconds(2.4f);

		//6降
		actions[5].GetComponent<GetPerformDown>().isGoDownSetter();
		yield return new WaitForSeconds(1);

		//6收
		for(float i=0;i<time/2;i+=Time.deltaTime)
		{
			actions[5].GetComponent<SpringJoint2D>().connectedAnchor=new Vector2(actions[5].GetComponent<SpringJoint2D>().connectedAnchor.x-Time.deltaTime*speed,actions[5].GetComponent<SpringJoint2D>().connectedAnchor.y);
			//actions[1].GetComponent<SpringJoint2D>().connectedAnchor=new Vector2(actions[1].GetComponent<SpringJoint2D>().connectedAnchor.x+Time.deltaTime*speed,actions[1].GetComponent<SpringJoint2D>().connectedAnchor.y);
			yield return null;
		}
		actions[5].SetActive(false);

		//7降
		actions[6].GetComponent<GetPerformDown>().isGoDownSetter();
		yield return new WaitForSeconds(1);

		//8降
		actions[7].GetComponent<GetPerformDown>().isGoDownSetter();
		yield return new WaitForSeconds(1);

		//9降
		actions[8].GetComponent<GetPerformDown>().isGoDownSetter();
		yield return new WaitForSeconds(1.3f);

		//10降
		actions[9].GetComponent<GetPerformDown>().isGoDownSetter();
		yield return new WaitForSeconds(1);

		//7,8,9,10收
		for(float i=0;i<time/2;i+=Time.deltaTime)
		{
			actions[6].GetComponent<SpringJoint2D>().connectedAnchor=new Vector2(actions[6].GetComponent<SpringJoint2D>().connectedAnchor.x-Time.deltaTime*speed,actions[6].GetComponent<SpringJoint2D>().connectedAnchor.y);
			actions[7].GetComponent<SpringJoint2D>().connectedAnchor=new Vector2(actions[7].GetComponent<SpringJoint2D>().connectedAnchor.x+Time.deltaTime*speed,actions[7].GetComponent<SpringJoint2D>().connectedAnchor.y);
			actions[8].GetComponent<SpringJoint2D>().connectedAnchor=new Vector2(actions[8].GetComponent<SpringJoint2D>().connectedAnchor.x-Time.deltaTime*speed,actions[8].GetComponent<SpringJoint2D>().connectedAnchor.y);
			actions[9].GetComponent<SpringJoint2D>().connectedAnchor=new Vector2(actions[9].GetComponent<SpringJoint2D>().connectedAnchor.x+Time.deltaTime*speed,actions[9].GetComponent<SpringJoint2D>().connectedAnchor.y);
			yield return null;
		}

		actions[6].SetActive(false);
		actions[7].SetActive(false);
		actions[8].SetActive(false);
		actions[9].SetActive(false);

		//11降
		actions[10].GetComponent<GetPerformDown>().isGoDownSetter();
		yield return new WaitForSeconds(1);

		//11收
		for(float i=0;i<time/3;i+=Time.deltaTime)
		{
			actions[10].GetComponent<SpringJoint2D>().connectedAnchor=new Vector2(actions[10].GetComponent<SpringJoint2D>().connectedAnchor.x-Time.deltaTime*speed,actions[10].GetComponent<SpringJoint2D>().connectedAnchor.y);
			//actions[1].GetComponent<SpringJoint2D>().connectedAnchor=new Vector2(actions[1].GetComponent<SpringJoint2D>().connectedAnchor.x+Time.deltaTime*speed,actions[1].GetComponent<SpringJoint2D>().connectedAnchor.y);
			yield return null;
		}
        actions[10].SetActive(false);
		yield return new WaitForSeconds(0.5f);

		actions[11].GetComponent<GetPerformDown>().isGoDownSetter();
		

	}

}
