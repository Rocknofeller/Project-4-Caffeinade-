using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Analytics;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject FPSController;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Resumed!!!");
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        float score = FPSController.GetComponent<ScoreManager>().score;
        AnalyticsResult analyticsResult = Analytics.CustomEvent("ScoreTracker", new Dictionary<string, object> { { "ScoreAtPause", score } });
        Debug.Log("analyticsResult: " + analyticsResult);

    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    private void Awake()
    {
  
        SendSessionInfo();
    }

    public void SendSessionInfo()
    {
        Debug.Log(Analytics.initializeOnStartup.ToString());

        var sessionId = AnalyticsSessionInfo.sessionId;
        var userId = AnalyticsSessionInfo.userId;

        Analytics.CustomEvent("Session", new Dictionary<string, object>
        {
            { "sessionId", sessionId },
            { "userId",userId },
            { "session state",AnalyticsSessionInfo.sessionState },
            { "machine", SystemInfo.deviceName },
        });
    }
}
