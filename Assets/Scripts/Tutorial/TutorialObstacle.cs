using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using static ObstaclePool;

public class TutorialObstacle : MonoBehaviour
{
    public Transform startPosition; // 장애물 나타나는 지점
    public Transform endPosition; // 장애물 사라지는 지점
    public Transform middlePosition;
    public float bpm;
    double currentTime = 0d;

    float trapTime = 0f;
    float arrowTime = 0f;

    public ObstaclePool obstaclePool;

    float[] drumbeatA = { 1, 1, 1, 1 };

    void Start()
    {

    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 60d / bpm)
        {
            ActivateObstacle();

            currentTime -= 60d / bpm;
        }
        
        arrowTime += Time.deltaTime;

        if (arrowTime > 8)
        {
            ActivateArrow();
            arrowTime = 0;
        }

        trapTime += Time.deltaTime;
        if (trapTime > 16)
        {
            ActivateArrow();
            trapTime = 0;
        }
    }

    /*void ActivateObstacle()
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
    }*/

    void ActivateObstacle()
    {
        ObstaclePool.ObstacleType randomType = (ObstaclePool.ObstacleType)Random.Range(0, System.Enum.GetValues(typeof(ObstaclePool.ObstacleType)).Length - 2);

        GameObject obstacle = obstaclePool.GetPooledObstacle(randomType);
        if (obstacle != null)
        {
            obstacle.SetActive(true);
            obstacle.transform.position = startPosition.position;
        }
        else
        {
            Debug.LogError("해당 타입 장애물 오브젝트가 풀에 없음 " + obstacle);
        }
    }
    void ActivateArrow()
    {
        GameObject arrow = obstaclePool.GetPooledObstacle(ObstacleType.Arrow);
        if (arrow != null)
        {
            arrow.SetActive(true);
            arrow.transform.position = startPosition.position;
        }
        else
        {
            Debug.LogError("해당 타입 장애물 오브젝트가 풀에 없음 " + arrow);
        }
    }
    void ActivateTrap()
    {
        GameObject trap = obstaclePool.GetPooledObstacle(ObstacleType.Trap);
        if (trap != null)
        {
            trap.SetActive(true);
            trap.transform.position = startPosition.position;
        }
        else
        {
            Debug.LogError("해당 타입 장애물 오브젝트가 풀에 없음 " + trap);
        }
    }

}
