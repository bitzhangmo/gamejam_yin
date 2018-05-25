// 创建标识: zhangMo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour {

	public float lifeTime=5f;

	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag=="Player"||other.gameObject.tag=="Light")
		{
			//TODO a shader
			Destroy(gameObject,lifeTime);
		}
	}

}
