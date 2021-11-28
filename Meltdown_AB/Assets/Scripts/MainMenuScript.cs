using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay"); 
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
    }
}
