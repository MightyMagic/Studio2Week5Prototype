using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("FinalSceneAndrei");
        Time.timeScale = 1.0f;
    }
}