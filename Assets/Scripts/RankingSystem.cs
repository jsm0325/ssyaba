using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RankingSystem : MonoBehaviour
{
    private int[] bestScore = new int[10];
    private string[] bestName = new string[10];
    public TextMeshProUGUI[] rankScoreText = new TextMeshProUGUI[10];
    public TextMeshProUGUI[] rankNameText = new TextMeshProUGUI[10];
    public TextMeshProUGUI rankNameCurrent;
    public TextMeshProUGUI rangkScoreCurrent;
    public void ScoreSet(int currentScore, string currentName)
    {
        PlayerPrefs.SetString("CurrentPlayerName", currentName);
        PlayerPrefs.SetInt("CurrentPlayerScore", currentScore);

        int tmpScore = 0;
        string tmpName = "";

        for (int i =0; i<10; i++)
        {
            bestScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");


            while (bestScore[i] < currentScore) 
            {
                tmpScore = bestScore[i];
                tmpName = bestName[i];
                bestScore[i] = currentScore;
                bestName[i] = currentName;

                PlayerPrefs.SetInt(i + "BestScore", currentScore);
                PlayerPrefs.SetString(i.ToString() + "BestName", currentName);

                currentScore = tmpScore;
                currentName = tmpName;

            }
        }
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetInt(i + "BestScore", bestScore[i]);
            PlayerPrefs.SetString(i.ToString() + "BestName", bestName[i]);
        }
    }

    public void ShowRanking()
    {
        rankNameCurrent.text = PlayerPrefs.GetString("CurrentPlayerName");
        rangkScoreCurrent.text = PlayerPrefs.GetInt("CurrentPlayerScore").ToString();
        for (int i = 0; i < 10; i++)
        {
            bestScore[i] = PlayerPrefs.GetInt(i + "BestScore");
            bestName[i] = PlayerPrefs.GetString(i + "BestName");
        }

        for (int i = 0; i < 10; i++)
        {
            rankScoreText[i].text = bestScore[i].ToString();
            rankNameText[i].text = bestName[i];



        }
    }
    public void SetRanking()
    {
        GameObject ranking = GameObject.Find("Ranking");
        for (int i =0; i < 10; i++)
        {
            rankNameText[i] = ranking.transform.GetChild(i).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            rankScoreText[i] = ranking.transform.GetChild(i).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        }
    }
}
