using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Wine : MonoBehaviour {

    public GameObject wine;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // if we want to change colour in UI
    }

    void Update()
    {
        if (GameManager.gotWine)
        {
            wine.SetActive(true);
            //or orig have blanket as grayscale and make it colour in UI when you pick it up?
        }
    }
}
