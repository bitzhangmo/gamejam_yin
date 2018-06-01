using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOtherObj : MonoBehaviour 
{
	private SphereCollider thiscollider;
	private void Start()
	{
		thiscollider = GetComponent<SphereCollider>();
		thiscollider.radius = GetComponent<LOSRadialLight>();
	}
	private void OnCollisionEnter(Collision other)
	{
		Ray ray = new Ray(transform.position, other.transform.position - transform.position);
		RaycastHit hit;
		if (Physics.Raycast(ray,out hit, Vector3.Magnitude(other.transform.position - transform.position)))
		{
			if (hit.transform.gameObject.tag == other.gameObject.tag)
			{
				other.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
			}
		}
	}
}
