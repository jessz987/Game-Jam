using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public bool lastKeyLeft;
    GameObject dialogueNPC;

    public KeyCode rightKey;
    public KeyCode leftKey;
    public KeyCode interactKey;
    
    Vector2 moveDirection = Vector2.zero;
    public float speed;

    Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    DialogueManager dialogueManager;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        dialogueManager = GetComponent<DialogueManager>();
    }
	
	void Update () {

        // end game check

        if (GameManager.gotBalloons && GameManager.gotBlanket && GameManager.gotBouquet && GameManager.gotWine && GameManager.gotRadio)
        {
            GameManager.gotEverything = true;
            Debug.Log("hooray u got errethang");
        }

        // movement code
        moveDirection *= 0.75f;
        
        if (Input.GetKey(rightKey))
        {
            moveDirection += Vector2.right;
            spriteRenderer.flipX = false;
            lastKeyLeft = false;
        }

        if (Input.GetKey(leftKey))
        {
            moveDirection += Vector2.left;
            spriteRenderer.flipX = true;
            lastKeyLeft = true;
        }
        else if (lastKeyLeft)
        {
            spriteRenderer.flipX = true;
        }

        // dialogue code

        if (dialogueNPC != null)
        {
            Debug.Log("in dialogue trigger");
            if (Input.GetKeyDown(interactKey))
            {
                Debug.Log("talking");
                if (dialogueManager.InConversation)
                {
                    dialogueManager.AdvanceConversation();
                }
                else
                {
                    dialogueManager.BeginConversation(dialogueNPC);
                }

            }
        }
        else
        {
            if (dialogueManager.InConversation)
            {
                dialogueManager.EndConversation();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "dialogue")
        {
            dialogueNPC = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (dialogueNPC != null)
        {
            dialogueNPC = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "endGameBlock")
        {
            Debug.Log("you didn't collect everything");
        }
    }

    void FixedUpdate()
    {
        // movement code
        rb.velocity = new Vector3(moveDirection.x * speed * Time.deltaTime, rb.velocity.y);
    }
}
