using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public int totalScore;
    [SerializeField] public TextMeshProUGUI scoreText;

    public static GameController instance;


    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText ()
    {
        scoreText.text = totalScore.ToString();
    }
}
