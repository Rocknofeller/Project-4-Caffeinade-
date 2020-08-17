using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefabs : MonoBehaviour
{
    public ScoreManager scoring;
    public GameObject controller;

    void Start()
    {
        controller = GameObject.Find("FPSController");
        scoring = controller.GetComponent<ScoreManager>();
    }

    void OnCollisionEnter(Collision other)
    {
        //Destroy(gameObject, 0.02f);

        if (other.gameObject.tag == "Chair")
        {
               
            Destroy(gameObject, 15f);
        }

        else if(other.gameObject.tag == "Coffee")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            scoring.score += 10f;
        }

    }
    
}
