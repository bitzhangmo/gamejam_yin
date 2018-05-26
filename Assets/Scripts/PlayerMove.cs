// 创建标识: zhangMo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LOS;

public class PlayerMove : MonoBehaviour
{
    [HideInInspector]
    private Transform p_transform;
    [SerializeField]
    private float offset;
    [SerializeField]
    private float disapearSpeed;
    private Rigidbody2D p_rigidbody;
    public SpriteRenderer sr;
    public int lightCount = 5;
    public float jumpHeight = 20f;
    public float moveSpeed = 5.0f;
    public bool isGrounded = true;
    public bool isShooting = false;
    public bool isDead = false;
    public Vector3 velocity;
    public GameObject LRLight;
    public Animator anim;
    public Sprite moveR;
    public Sprite moveL;

    void Awake()
    {
        p_transform = GetComponent<Transform>();
        p_rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Debug.Log(transform.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShooting && !isDead)
            Move();
        else if (isDead)
        {
            LRLight.SetActive(false);
            anim.enabled = false;
            PlayerDead();
        }
    }

    void Move()
    {
        //float randomUp = Random.Range(-offset, offset);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //transform.Translate(Vector3.up*30.0f*Time.deltaTime);
            p_rigidbody.AddForce(new Vector3(0, jumpHeight, 0));
            isGrounded = false;
            Debug.Log("W");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            p_transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (sr.sprite != moveL)
            {
                //anim.SetFloat("turn", -1);
                sr.sprite = moveL;
            }
            Debug.Log("A");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            p_transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (sr.sprite != moveR)
            {
                //anim.SetFloat("turn", 1);
                sr.sprite = moveR;
            }
            Debug.Log("D");
        }
        else
        {
            anim.SetFloat("turn", 0);
        }
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void PlayerDead()
    {
        sr.color = Color.Lerp(sr.color, Color.clear, Time.deltaTime * disapearSpeed);
    }

}
