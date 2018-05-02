using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class BGMusicController : MonoBehaviour {

    public AudioClip backgroundMusic;
    AudioSource bgMusic;
    Scene currentScene;


    private void Start()
    {
        bgMusic = SoundController.me.PlaySound(backgroundMusic);

        currentScene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        string sceneName = currentScene.name;

        if (sceneName == "MainMenu")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bgMusic.Stop();
            }
        }
    }
}
