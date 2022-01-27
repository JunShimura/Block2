using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    string scoreHeader = "SCORE:";
    [SerializeField]
    string scoreFomat = "D5";
    private int _score = 0;
    public int Score
    {
        set {
            if (_score != value)
            {
                _score = value;
                UpdateValue();
            }
        }
        get
        {
            return _score;
        }
    }

    private Text uiText;
    private void Awake()
    {
        uiText = GetComponent<Text>();
        UpdateValue();
    }
    private void UpdateValue()
    {
        uiText.text = scoreHeader + _score.ToString(scoreFomat);
    }
}
