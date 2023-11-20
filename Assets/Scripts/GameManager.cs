using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private int currentHp = 0;
    private int maxHp = 5;
    private int score = 0;
    private int currency = 0;



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

    }



    // ü�� ����
    public void DecreaseHp(int damage)
    {
        if (currentHp > 0)
        {
            currentHp -= damage;
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
        score -=amount;
    }


    // ��ȭ ����
    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }
    public void DecreaseCurrency(int amount)
    {
        currency -= amount;
    }

    // ���� �¸� �� �й� ����
    public void GameOver()
    {
        
    }

    public void GameClear()
    {

    }
}
