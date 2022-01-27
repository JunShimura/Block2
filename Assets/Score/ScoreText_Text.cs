using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText_Text : MonoBehaviour
{
    ScoreText scoreText;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<ScoreText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            scoreText.Score++;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            scoreText.Score=99999;
        }

    }
}
