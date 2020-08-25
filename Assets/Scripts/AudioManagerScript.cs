using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    //all the sound effects except background music

    

    public static AudioClip Cash;

    static AudioSource beep;

    void Start()
    {
        Cash = Resources.Load<AudioClip>("cashRegSound");

        beep = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "cashRegSound":
                beep.PlayOneShot(Cash);
                break;

        }
    }
}
