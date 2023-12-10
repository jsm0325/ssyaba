using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private int currentHp = 0;
    private int maxHp = 5;
    private int score = 0;
    private string playerName = "No Name";
    private bool cameraEffectState = true;
    private bool isPaused = false;
    private bool isStarted = false;
    private RankingSystem rankingSystem;
    
    public AudioManager audioManager;
    public List<GameObject> hp;
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
        
        if (audioManager == null)
        {
            audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        }
        if (hp.Count != 5)
        {
            hp = new List<GameObject>(new GameObject[5]);
        }
        if (SceneManager.GetActiveScene().name == "MainStage" && isStarted == false)
        {
            GameStart();
        }

        if (hp[1] == null && GameObject.Find("hp1") != null)
        {
            hp[0] = GameObject.Find("hp1") ?? throw new System.Exception("hp1 not found");
            hp[1] = GameObject.Find("hp2") ?? throw new System.Exception("hp2 not found");
            hp[2] = GameObject.Find("hp3") ?? throw new System.Exception("hp3 not found");
            hp[3] = GameObject.Find("hp4") ?? throw new System.Exception("hp4 not found");
            hp[4] = GameObject.Find("hp5") ?? throw new System.Exception("hp5 not found");
        }
    }

    public int GetHealth()
    {
        return currentHp;
    }

    // 체력 관리
    public void DecreaseHp(int damage)
    {
        if (currentHp > 0)
        {

            currentHp -= damage;
            Debug.LogError(currentHp);
            hp[currentHp].gameObject.SetActive(false);
        }
        if (currentHp == 0)
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
    public void GameStart()
    {
        isStarted = true;

        audioManager.PlayBGM("BGM");

    }

    // 게임 승리 및 패배 관리
    public void GameOver()
    {
        // 실패 화면 및 점수
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
        audioManager.PlaySFX("Fail");
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
        audioManager.PlaySFX("Clear");
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
    public void ReSetIsPaused()
    {
        isPaused = false;
        Time.timeScale = 1;
    }

    public void ResetGame()
    {
        currentHp = maxHp;
        score = 0;
        isPaused = false;
        Time.timeScale = 1;
        isStarted = false;
    }
}