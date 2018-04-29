using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Balloons : MonoBehaviour {

    public GameObject balloons;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // if we want to change colour in UI
    }

    void Update()
    {
        if (GameManager.gotBalloons)
        {
            balloons.SetActive(true);
            Debug.Log("UI Radio active");
            //or orig have blanket as grayscale and make it colour in UI when you pick it up?
        }
    }
}
