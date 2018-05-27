
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brighten : MonoBehaviour {

	private SpriteRenderer render;
    private AudioSource audio;
	public MoveInDirection toMove;
    public GameObject fire;
    public GameObject[] nextLevel;
    public GameObject[] smallObject;
    public GameObject nextLamp;
    public GameObject destroyIt;


    private void Awake()
    {
        audio = GetComponent<AudioSource>();
		render=GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
		if(other.gameObject.tag=="Player"||other.gameObject.tag=="Light")
		{
            audio.Play();
            if (other.gameObject.tag == " Light")
            {
                Destroy(other.gameObject);
            }
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
            if (nextLamp != null)
            {
                nextLamp.SetActive(true);
            }
            if (destroyIt != null)
            {
                Destroy(destroyIt);
            }
            if (smallObject != null)
            {
                for (int i = 0; i < smallObject.Length; i++)
                {
                    //smallObject[i].GetComponent<ChangeObject>().isSmaller = true;
                    //Destroy(smallObject[i]);
                    smallObject[i].SetActive(false);
                }
            }
            render.color = Color.white;
            Debug.Log("Fire");
            fire.SetActive(true);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
	}

}
