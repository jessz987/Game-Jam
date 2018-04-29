using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("start game");
            SceneManager.LoadScene("Scene1");
        }


    }

    public void onClick()
    {
        SceneManager.LoadScene("Scene1");
    }
    void onTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            Debug.Log("player");
            if (Input.GetKeyDown("space"))
            {
                Debug.Log("start game");
                SceneManager.LoadScene("Scene1");
            }
        }
    }
}
