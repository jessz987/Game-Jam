﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.gotRadio = true;
            gameObject.SetActive(false);
        }
    }
}
