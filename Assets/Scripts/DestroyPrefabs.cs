using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefabs : MonoBehaviour
{
   
        void OnCollisionEnter(Collision other)
        {
        

            //Destroy(gameObject, 0.02f);

            if (other.gameObject.tag == "Chair")
            {
               
                Destroy(gameObject, 15f);
            }

        }
    
}
