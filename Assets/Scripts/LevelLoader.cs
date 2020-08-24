using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    bool haveSpin = false;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(haveSpin);
        if(Input.GetMouseButtonDown(0) && haveSpin == false)
        {
            haveSpin = true;
            Debug.Log(haveSpin);
        }
        else if (Input.GetMouseButtonDown(0) && haveSpin == true)
        {
            LoadNextLevel();
        }
        
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
        AnalyticsEvent.LevelStart(SceneManager.GetActiveScene().name, SceneManager.GetActiveScene().buildIndex);
    }
}
