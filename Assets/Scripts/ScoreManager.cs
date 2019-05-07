using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {

    private static ScoreManager _instace;
    public static ScoreManager Instace{
        get {
            return _instace;
        }
        private set
        {
            _instace = value;
        }
    }

    public int Score { get; private set; }

    [SerializeField] private string ScoreTextAppend = "Score: ";

    private TextMeshProUGUI _text;

    private void Awake()
    {
        if (Instace == null)
        {
            Instace = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _text = GetComponent<TextMeshProUGUI>();
        UpdateScoretext();
    }

    public void AddScore(int score)
    {
        Score += score;
        //update the score text
        UpdateScoretext();
    }

    private void UpdateScoretext()
    {
        _text.text = ScoreTextAppend + Score.ToString("00000");
    }
}
