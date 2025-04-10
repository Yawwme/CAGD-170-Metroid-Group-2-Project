using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 *Ricky Pardo
 * 4 / 1 / 2025
 * main menu screen UI and map loading
 * 
 */
public class MenuScreen : MonoBehaviour
{
    public void PlayButtonPressed(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);


    }
   
    public void QuitButtonPressed()
    {
        print("Quit Game");
        Application.Quit();
    }
}
