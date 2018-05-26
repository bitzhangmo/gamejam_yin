// 创建标识: zhangMo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour {

	//public float lifeTime=5f;
    public Renderer destroyRender;
    public Material material;
    public GameObject father;

    [Range(0.01f, 1.0f)]
    public float burnSpeed = 0.3f;

    private float burnAmount = 0.0f;

    private void Start()
    {
        material = destroyRender.material;
        material.SetFloat("_BurnAmount", 0.0f);
    }


    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag=="Player")
		{
            Debug.Log("Destroy");
            StartCoroutine(BurnIt());
		}
	}

    private IEnumerator BurnIt()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("Destroy2");
            burnAmount = i * 0.1f;
            material.SetFloat("_BurnAmount", burnAmount);
            yield return new WaitForSeconds(burnSpeed);
        }
        father.SetActive(false);
    }

}
