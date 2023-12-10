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
    // �̱������� ���ӸŴ��� �����ؼ� ��� ��ũ��Ʈ������ ���ӸŴ��� �ҷ��� �� �ְ� ����ȯ�� ���ӸŴ��� ��������ʵ��� ��
    public static GameManager Instance
    {
        get
        {
            // �ν��Ͻ��� ���� ��쿡 �����Ϸ� �ϸ� �ν��Ͻ��� �Ҵ�
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
        // �ν��Ͻ��� �����ϴ� ��� ���λ���� �ν��Ͻ��� ����
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        //���� ��ȯ�Ǵ��� ����Ǿ��� �ν��Ͻ��� �ı����� ����
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

    // ü�� ����
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


    // ���� ���� ���� ScoreManager�� ���� �����Ҽ���
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

    // ���� �¸� �� �й� ����
    public void GameOver()
    {
        // ���� ȭ�� �� ����
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
        // ���� ȭ�� �� ����
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