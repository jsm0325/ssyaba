using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRanking : MonoBehaviour
{
    public RankingSystem rankingSystem;

    private void OnEnable()
    {
        rankingSystem.SetRanking();
        rankingSystem.ShowRanking();
    }

}
