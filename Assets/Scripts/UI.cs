using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 *Name: Jann Morales
 * Date: 4 / 2 / 2025
 * Last Updated: 4 / 2 / 2025
 * Description: Handles UI text for lives and gold
 */

public class UI : MonoBehaviour
{
    public TMP_Text livesText;
    public TMP_Text gold;
   
    public SamusController playerController;

    // Update is called once per frame
    void Update()
    {
        //Sets the lives text box value equal to the player's lives
        livesText.text = "Lives: " + playerController.health;

        //Sets the gold text box value equal to the player's gold
        gold.text = "Gold: " + playerController.coin;
       
    }
}
