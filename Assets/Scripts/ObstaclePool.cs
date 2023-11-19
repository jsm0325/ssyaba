using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{

    // 장애물 프리팹
    public GameObject logPrefab;
    public GameObject arrowPrefab;
    public GameObject rockPrefab;
    public GameObject trapPrefab;


    public int poolSize = 4;           // 풀 크기

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
        // 풀 초기화
        InitializePools();
    }


    void InitializePools()
    {
        obstaclePools = new Dictionary<ObstacleType, List<GameObject>>();

        // 각각의 종류에 대한 풀 초기화
        InitializePool(ObstacleType.Log, logPrefab);
        InitializePool(ObstacleType.Arrow, arrowPrefab);
        InitializePool(ObstacleType.Rock, rockPrefab);
        InitializePool(ObstacleType.Trap, trapPrefab);
    }



    // 풀링한 오브젝트 리턴 받기
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
            Debug.LogError("키값 타입 못찾음");
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
                Debug.LogError("정의되지 않은 타입");
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
            obstacle.transform.SetParent(transform);  // 부모 설정
        }

        obstaclePools.Add(type, pool);
    }
}
