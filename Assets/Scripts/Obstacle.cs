using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private ObstacleController obstacleCotroller;
    public float moveSpeed = 5f;   // 이동 속도
    private void Start()
    {
        obstacleCotroller = GameObject.Find("ObstacleController").GetComponent<ObstacleController>();
    }
    void Update()
    {
        // 장애물이 도착 지점에 도달하면 초기화
        if (Vector3.Distance(transform.position, obstacleCotroller.endPosition.position) < 0.1f)
        {
            ResetObstacle();
        }
        else
        {
            MoveToDestination();
        }
    }
    private void MoveToDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position, obstacleCotroller.endPosition.position, moveSpeed * Time.deltaTime);
    }
    // 장애물이 endPoint 도착하면 비활성화 후 원래 위치로 초기화
    void ResetObstacle()
    {
        // 비활성화되고 시작 지점으로 이동
        gameObject.SetActive(false);
        transform.position = obstacleCotroller.startPosition.position;
    }
}
