using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouquetController : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.gotBouquet = true;
            Debug.Log("picked up bouquet");
            gameObject.SetActive(false);
        }
    }
}
