using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float score;
    public float cash;

    public Text scoreText;
    public Text cashText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        cash = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cash = score / 10;

        scoreText.text = /*"Score: " +*/ score.ToString("0");
        cashText.text = /*"Cash: $" + */cash.ToString("0");
    }
}
