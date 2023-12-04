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
        if (GameObject.Find("hp1") != null)
        {
            hp.Add(GameObject.Find("hp1"));
            hp.Add(GameObject.Find("hp2"));
            hp.Add(GameObject.Find("hp3"));
            hp.Add(GameObject.Find("hp4"));
            hp.Add(GameObject.Find("hp5"));
        }
    }



    // ü�� ����
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


    // ���� �¸� �� �й� ����
    public void GameOver()
    {
        // ���� ȭ�� �� ����
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
        // ���� ȭ�� �� ����
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