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
        Cash = Resources.Load<AudioClip>("CashRegister");

        beep = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "CashRegister":
                beep.PlayOneShot(Cash);
                break;

            


        }
    }
}
