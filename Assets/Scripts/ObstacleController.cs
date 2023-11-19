using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Transform startPosition; // 장애물 나타나는 지점
    public Transform endPosition; // 장애물 사라지는 지점

    public ObstaclePool obstaclePool;

    void Start()
    {
        // 시작할 때 3초마다 ActivateObstacle 함수를 호출
        InvokeRepeating("ActivateObstacle", 0f, 3f);
    }

    void ActivateObstacle()
    {
        // 랜덤하게 장애물 종류 선택
        ObstaclePool.ObstacleType randomType = (ObstaclePool.ObstacleType)Random.Range(0, System.Enum.GetValues(typeof(ObstaclePool.ObstacleType)).Length);

        GameObject obstacle = obstaclePool.GetPooledObstacle(randomType);

        // 장애물 활성화
        if (obstacle != null)
        {
            obstacle.SetActive(true);
            obstacle.transform.position = startPosition.position;
        }
        else
        {
            Debug.LogError("해당 타입 장애물 오브젝트가 풀에 없음 " + randomType);
        }
    }

}
