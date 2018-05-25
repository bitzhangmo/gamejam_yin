using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brighten : MonoBehaviour {

	private SpriteRenderer render;

	private void Awake() {
		render=GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="Player"||other.gameObject.tag=="Light")
		{
			render.color=Color.white;
		}
	}
}
