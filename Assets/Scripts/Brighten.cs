
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brighten : MonoBehaviour {

	private SpriteRenderer render;
	public MoveInDirection toMove;
    public GameObject fire;
    public GameObject[] nextLevel;

	private void Awake()
    {
		render=GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
		if(other.gameObject.tag=="Player"||other.gameObject.tag=="Light")
		{
            if (toMove != null)
            {
                toMove.isToMove = true;
            }
            if (nextLevel != null)
            {
                for (int i = 0; i < nextLevel.Length; i++)
                {
                    nextLevel[i].GetComponent<ChangeObject>().isStart = true;
                }
            }
            render.color = Color.white;
            Debug.Log("Fire");
            fire.SetActive(true);
        }
	}

}
