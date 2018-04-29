using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public bool lastKeyLeft;
    GameObject npc;

    public KeyCode rightKey;
    public KeyCode leftKey;
    public KeyCode interactKey;
    
    Vector2 moveDirection = Vector2.zero;
    public float speed;

    Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	void Update () {

        moveDirection *= 0.75f;
        
        if (Input.GetKey(rightKey))
        {
            lastKeyLeft = false;
            moveDirection += Vector2.right;
            Debug.Log("move right");
            spriteRenderer.flipX = false;
        }

        if (Input.GetKey(leftKey))
        {
            moveDirection += Vector2.left;
            Debug.Log("move left");
            spriteRenderer.flipX = true;
            lastKeyLeft = true;
        }
        else if (lastKeyLeft)
        {
            spriteRenderer.flipX = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x * speed * Time.deltaTime, rb.velocity.y);
    }
}
