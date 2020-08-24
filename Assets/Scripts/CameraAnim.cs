using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnim : MonoBehaviour
{
    public float xRot;

    // Start is called before the first frame update
    void Start()
    {
        xRot = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown (0))
        {
            xRot = .5f;
        }

        this.gameObject.transform.Rotate(xRot, 0f, 0f);

        if (this.gameObject.transform.rotation.x >= 0f)
        {
            xRot = 0;
        }
    }

}
