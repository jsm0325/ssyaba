using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{

    // ��ֹ� ������
    public GameObject logPrefab;
    public GameObject arrowPrefab;
    public GameObject rockPrefab;
    public GameObject trapPrefab;


    public int poolSize = 4;           // Ǯ ũ��

    private Dictionary<ObstacleType, List<GameObject>> obstaclePools;

    public enum ObstacleType
    {
        Log,
        Arrow,
        Rock,
        Trap
    }

    void Start()
    {
        // Ǯ �ʱ�ȭ
        InitializePools();
    }


    void InitializePools()
    {
        obstaclePools = new Dictionary<ObstacleType, List<GameObject>>();

        // ������ ������ ���� Ǯ �ʱ�ȭ
        InitializePool(ObstacleType.Log, logPrefab);
        InitializePool(ObstacleType.Arrow, arrowPrefab);
        InitializePool(ObstacleType.Rock, rockPrefab);
        InitializePool(ObstacleType.Trap, trapPrefab);
    }



    // Ǯ���� ������Ʈ ���� �ޱ�
    public GameObject GetPooledObstacle(ObstacleType type)
    {
        if (obstaclePools.ContainsKey(type))
        {
            List<GameObject> pool = obstaclePools[type];

            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].activeInHierarchy)
                {
                    return pool[i];
                }
            }

            GameObject newObstacle = Instantiate(GetPrefabByType(type));
            pool.Add(newObstacle);
            return newObstacle;
        }
        else
        {
            Debug.LogError("Ű�� Ÿ�� ��ã��");
            return null;
        }
    }

    GameObject GetPrefabByType(ObstacleType type)
    {
        switch (type)
        {
            case ObstacleType.Log:
                return logPrefab;
            case ObstacleType.Arrow:
                return arrowPrefab;
            case ObstacleType.Rock:
                return rockPrefab;
            case ObstacleType.Trap:
                return trapPrefab;
            default:
                Debug.LogError("���ǵ��� ���� Ÿ��");
                return null;
        }
    }

    void InitializePool(ObstacleType type, GameObject prefab)
    {
        List<GameObject> pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obstacle = Instantiate(prefab);
            obstacle.SetActive(false);
            pool.Add(obstacle);
            obstacle.transform.SetParent(transform);  // �θ� ����
        }

        obstaclePools.Add(type, pool);
    }
}
