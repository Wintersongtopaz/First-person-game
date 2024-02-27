using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public Health playerHealth;
    public Image[] heartImages;
    int health = 0;

    void Awake()
    {
        // Use FindObjectOfType of find a Health script in the scene.
        FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerHealth) return;

        if (health != playerHealth.healthAmount) UpdateHealth();
    }

    // This function will be use to regularly update the hearts on screen to match how much health the player has.
    void UpdateHealth()
    {
        health = playerHealth.healthAmount;

        // Create a for loop that will loop through the heart images array.
        /*
            For each iteration(i), if the current value of i, is less than health,
            set that heart to be enabled (heartImages[i].enabled = true).
            Otherwise, set that heart to be disabled (heartImages[i].enabled = false).
                */
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < health) heartImages[i].enabled = true;
            else heartImages[i].enabled = false;
        }
    }
}
