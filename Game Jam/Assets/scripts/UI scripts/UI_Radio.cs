using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Radio : MonoBehaviour {

    public GameObject radio;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // if we want to change colour in UI
    }

    void Update()
    {
        if (GameManager.gotRadio)
        {
            radio.SetActive(true);
            //or orig have blanket as grayscale and make it colour in UI when you pick it up?
        }
    }
}
