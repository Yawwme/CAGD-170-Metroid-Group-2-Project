using UnityEngine;
using UnityEngine.SceneManagement;
/*
 *Ricky Pardo
 * 4 / 1 / 2025
 * gameover screen UI and map loading
 * 
 */
public class GameOverScreen : MonoBehaviour
{
    public void PlayButtonPressed(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);


    }
    /// <summary>
    /// this function will be called to quit the game 
    /// when the quit button is pressed
    /// </summary>
    public void QuitButtonPressed()
    {
        print("Quit Game");
        Application.Quit();
    }



}