using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScore : MonoBehaviour
{

    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI highScore;
    private void OnEnable()
    {
        currentScore.text = GameManager.Instance.GetScore().ToString();
        highScore.text = PlayerPrefs.GetInt(0 + "BestScore").ToString();
    }
}
