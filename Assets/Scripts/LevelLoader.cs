using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    bool haveSpin = false;
    public GameObject instructions;

    // Update is called once per frame
    void Update()
    {
        //Place Menu Items here in the Level Loader
        if(Input.GetMouseButtonDown(0) && haveSpin == false)
        {
            haveSpin = true;
            Debug.Log(haveSpin);
            instructions.SetActive(false);
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
    }
}
