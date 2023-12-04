using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private int currentHp = 0;
    private int maxHp = 5;
    private int score = 0;
    private string playerName = "No Name";
    private bool cameraEffectState = true;
    private bool isPaused = false;
    private RankingSystem rankingSystem;
    public List<GameObject> hp = new List<GameObject>();
    // 싱글톤으로 게임매니저 선언해서 어느 스크립트에서나 게임매니저 불러올 수 있고 씬전환시 게임매니저 사라지지않도록 함
    public static GameManager Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        //씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않음
        DontDestroyOnLoad(gameObject);
    }



    void Start()
    {
        currentHp = maxHp;


    }


    void Update()
    {
        if (GameObject.Find("hp1") != null)
        {
            hp.Add(GameObject.Find("hp1"));
            hp.Add(GameObject.Find("hp2"));
            hp.Add(GameObject.Find("hp3"));
            hp.Add(GameObject.Find("hp4"));
            hp.Add(GameObject.Find("hp5"));
        }
    }



    // 체력 관리
    public void DecreaseHp(int damage)
    {
        if (currentHp > 0)
        {

            currentHp -= damage;
            Debug.LogError(currentHp);
            GameObject.Destroy(hp[currentHp]);
        }
        else if (currentHp == 0)
        {
            GameOver();
        }
    }

    public void IncreaseHp(int amount)
    {
        currentHp += amount;
    }


    // 점수 관리 따로 ScoreManager로 빼서 관리할수도
    public void IncreaseScore(int amount)
    {
        score += amount;
    }
    public void DecreaseScore(int amount)
    {
        score -= amount;
    }

    public int GetScore()
    {
        return score;
    }


    // 게임 승리 및 패배 관리
    public void GameOver()
    {
        // 실패 화면 및 점수
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
        if(rankingSystem ==null)
        {
            rankingSystem = GameObject.Find("RankingManager").GetComponent<RankingSystem>();
        }
        rankingSystem.ScoreSet(score, playerName);
        SetIsPaused();
    }

    public void GameClear()
    {
        // 성공 화면 및 점수
        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
        if (rankingSystem == null)
        {
            rankingSystem = GameObject.Find("RankingManager").GetComponent<RankingSystem>();
        }
        rankingSystem.ScoreSet(score,playerName);
        SetIsPaused();
    }

    public void SetName(TextMeshProUGUI Inputname)
    {
        playerName = Inputname.text;
    }

    public void SetCameraEffectState()
    {
        cameraEffectState = !cameraEffectState;
    }
    public void ReSetCameraEffectState()
    {
        cameraEffectState = true;
    }
    public bool ReturnCameraEffectState()
    {
        return cameraEffectState;
    }

    public void SetIsPaused()
    {
        if (isPaused == true)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else if (isPaused == false)
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}