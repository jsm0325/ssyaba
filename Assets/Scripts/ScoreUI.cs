using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;


    private void Update()
    {
        scoreText.text = "Score : " + GameManager.Instance.GetScore();
    }
}
