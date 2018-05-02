using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    /*
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("start game");
            SceneManager.LoadScene("Gameplay");
        }
        

    }
    
    public void onClick()
    {
        SceneManager.LoadScene("Scene1");
    }
    */

    void OnTriggerStay2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("space"))
            {
                Debug.Log("start game");
                SceneManager.LoadScene("Gameplay");
            }
        }
    }
}
