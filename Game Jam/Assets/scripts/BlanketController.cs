using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlanketController : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.gotBlanket = true;
            Debug.Log("picked up blanket");
            gameObject.SetActive(false);
        }
    }
}
