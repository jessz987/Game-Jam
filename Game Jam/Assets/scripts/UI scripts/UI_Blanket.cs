using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Blanket : MonoBehaviour {

    public GameObject blanket;
    private SpriteRenderer spriteRenderer;

    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>(); // if we want to change colour in UI
    }
	
	void Update () {
		if (GameManager.gotBlanket)
        {
            blanket.SetActive(true);
            //or orig have blanket as grayscale and make it colour in UI when you pick it up?
        }
	}
}
