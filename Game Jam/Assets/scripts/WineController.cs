using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineController : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.gotWine = true;
            Debug.Log("picked up wine");
            gameObject.SetActive(false);
        }
    }
}
