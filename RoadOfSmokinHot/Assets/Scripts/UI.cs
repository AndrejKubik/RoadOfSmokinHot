using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject victoryText;
    [SerializeField] private GameObject defeatText;
    [SerializeField] private GameObject restartButton;

    private void Update()
    {
        if (GameManager.instance.playerWon) //if the player has won
        {
            victoryText.SetActive(true); //show the victory text
            restartButton.SetActive(true); //show the restart button
        }
        else if (GameManager.instance.playerLost) //if the player lost
        {
            defeatText.SetActive(true); //show defeat text
            restartButton.SetActive(true); //show the restart button
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single); //reload the current scene
        Debug.Log("kurac");
    }
}
