
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brighten : MonoBehaviour {

	private SpriteRenderer render;
	public MoveInDirection toMove;
    public GameObject fire;
    public Transform firePoint;
	private void Awake()
    {
		render=GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
		if(other.gameObject.tag=="Player"||other.gameObject.tag=="Light")
		{
			render.color=Color.white;
			toMove.isToMove=true;
            Debug.Log("Fire");
            Instantiate(fire, firePoint.position, firePoint.rotation);
        }
	}

}
