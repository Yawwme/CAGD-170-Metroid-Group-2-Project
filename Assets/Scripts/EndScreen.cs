using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * Author: Jann Morales
 * Date Created: 3/4/2025
 * Last Updated: 4/2/2025
 * Descripton: This is the same scene script from Harvester. I know how lazy.
 * Allows the Player to go between scenes or quit the game
 */
public class EndScreen : MonoBehaviour
{
    /// <summary>
    /// Calls the function to load the main game 
    /// scene when the play button is pressed
    /// </summary>
    public void PlayButtonPressed(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    /// <summary>
    /// Calls the function to quit the game 
    /// when the quit button is pressed
    /// </summary>
    public void QuitButtonPressed()
    {
        print("Quit Game");
        Application.Quit();
    }
}
