using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public bool lastKeyLeft;
    GameObject dialogueNPC;
    public GameObject rightNotificationPrefab;
    public GameObject leftNotificationPrefab;
        
    public KeyCode rightKey;
    public KeyCode leftKey;
    public KeyCode interactKey;
    public KeyCode bellKey;
    
    Vector2 moveDirection = Vector2.zero;
    public float speed;

    Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    DialogueManager dialogueManager;

    public AudioClip bikePedalingSound;
    public AudioClip bikeRingSound;
    public AudioClip birdChirpSound;
    public AudioClip backgroundMusic;

    AudioSource bikeAudio;

    float chirpCountDown;
    float currentChirpCountDown;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        dialogueManager = GetComponent<DialogueManager>();
        currentChirpCountDown = chirpCountDown;
    }
	
	void Update () {

        GameManager.playerPosition = gameObject.transform.position;

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

        // audio code
            
            // bike pedal audio

        if (Input.GetKeyDown(leftKey))
        {
            bikeAudio = SoundController.me.PlaySound(bikePedalingSound);
        }

        if (Input.GetKeyUp(leftKey))
        {
            bikeAudio.Stop();
        }

        if (Input.GetKeyDown(rightKey))
        {
            bikeAudio = SoundController.me.PlaySound(bikePedalingSound);
        }

        if (Input.GetKeyUp(rightKey))
        {
            bikeAudio.Stop();
        }

            // bell ring audio

        if (Input.GetKeyDown(bellKey))
        {
            SoundController.me.PlaySoundJitter(bikeRingSound, 1f, 0.2f, 1.3f, 0.5f);
        }

            // bird chirp audio

        currentChirpCountDown -= Time.deltaTime;

        if (currentChirpCountDown < 0)
        {
            chirpCountDown = Random.Range(5, 20);
            Debug.Log("chirp count down: " + chirpCountDown);
            SoundController.me.PlaySoundJitter(birdChirpSound, 1f, 0.2f, 1.3f, 0.5f);
            currentChirpCountDown = chirpCountDown;
            Debug.Log("bird chirp");
        }

        // dialogue code

        if (dialogueNPC != null)
        {
            if (lastKeyLeft)
            {
                leftNotificationPrefab.SetActive(true);
                rightNotificationPrefab.SetActive(false);
            }
            else
            {
                rightNotificationPrefab.SetActive(true);
                leftNotificationPrefab.SetActive(false);
            }

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
            leftNotificationPrefab.SetActive(false);
            rightNotificationPrefab.SetActive(false);

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
