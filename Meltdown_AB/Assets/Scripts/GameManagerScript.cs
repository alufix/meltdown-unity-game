using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManagerScript : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject completeLevelUI;


    public void Update()
    {
        // check if fires or leaks left 
        // if none left: GameComplete(); 
        if (GameObject.FindGameObjectsWithTag("Fire").Length == 0) 
        {
            if (GameObject.FindGameObjectsWithTag("Leak").Length == 0)
            {
                Invoke("GameComplete", 1.5f);
            } 
        }

        //if user presses M, go to menu 
        if (Input.GetKeyDown(KeyCode.M))
        {
            LoadMenu(); 
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }

    public void GameComplete()
    { 
        //display UI 
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true; 
            //Debug.Log("GAME OVER");

            //Restart game 
            Invoke("Restart", 1f); 
        }
    }

    void Restart()
    {
        SceneManager.LoadScene("GamePlay"); 
    }
}
