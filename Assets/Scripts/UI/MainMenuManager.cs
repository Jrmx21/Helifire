using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    // load scene playscene
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("PlayScene");
    }
}
