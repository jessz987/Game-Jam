using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toEnd : MonoBehaviour {

    void OnTriggerStay2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            
                SceneManager.LoadScene("EndScene");
            
        }
    }
}
