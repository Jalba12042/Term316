using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject wintext;
    public float PointsToWin = 0;
    private bool gameEnded = false;

    public TextMeshProUGUI scoreText;

    void Awake()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {

        UpdatePointsText();

        // Check if PointsToWin equals 5 and the game hasn't ended yet
        if (PointsToWin >= 5 && !gameEnded)
        {

            wintext.SetActive(true);
            Time.timeScale = 0f;
            gameEnded = true;
        }

        // Restart the scene if 'R' key is pressed
        if (Input.GetKeyDown(KeyCode.R) )
        {
            RestartScene();
        }
    }

    // Function to restart the current scene
    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Reset time scale in case it was set to 0
        Time.timeScale = 1f;
    }

    void UpdatePointsText()
    {
        // Check if pointsText is assigned
        if (scoreText != null)
        {
            // Update the text to display the current value of PointsToWin
            scoreText.text = "Kills: " + PointsToWin.ToString();
        }
    }
}
