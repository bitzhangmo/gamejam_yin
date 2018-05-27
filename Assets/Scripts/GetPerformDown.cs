using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPerformDown : MonoBehaviour {

	public bool isGoDown=false;
	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
		rb2d=this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isGoDown)
			rb2d.constraints=new RigidbodyConstraints2D();
	}
}
