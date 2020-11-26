using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void PlayGame()
    {
        // Data Base Scenes to Change
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        //Working
        Debug.Log("Quit");

        //Quit Game Totally
        Application.Quit();
    }
}
