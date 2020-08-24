using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefabs : MonoBehaviour
{
    public ScoreManager scoring;
    public GameObject controller;
    public GameObject heart;
    public Transform heartTransform;

    private Vector3 pos;
    private Quaternion rotation;

    void Start()
    {
        controller = GameObject.Find("FPSController");
        scoring = controller.GetComponent<ScoreManager>();
        pos = heartTransform.transform.position;
        rotation = heartTransform.transform.rotation;

    }

    void OnCollisionEnter(Collision other)
    {
        //Destroy(gameObject, 0.02f);
        
        //Object auto destroys itself after 15 seconds
        if (other.gameObject.tag == "Chair")
        {
               
            Destroy(gameObject, 15f);

        }


        //Object gets destroyed when hit by coffee
        else if(other.gameObject.tag == "Coffee")
        {

            Instantiate(heart, pos, rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
            scoring.score += 10f; 
        }
    }

}
