using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonsController : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.gotBalloons = true;
            Debug.Log("picked up balloons");
            gameObject.SetActive(false);
        }
    }
}
