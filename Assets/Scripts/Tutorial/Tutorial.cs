using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public TutorialObstacle tutorialController;
    public float moveSpeed = 5f;   // 이동 속도

    private void Start()
    {
        tutorialController = GameObject.Find("ObstacleController").GetComponent<TutorialObstacle>();
    }
    void Update()
    {
        // 장애물이 도착 지점에 도달하면 초기화
        if (Vector3.Distance(transform.position, tutorialController.endPosition.position) < 0.1f)
        {
            ResetObstacle();
        }
        else
        {
            MoveToDestination();
        }
    }
    //목표지점 시간에 따른 이동
    private void MoveToDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position, tutorialController.endPosition.position, moveSpeed * Time.deltaTime);
    }
    // 장애물이 endPoint 도착하면 비활성화 후 원래 위치로 초기화
    public void ResetObstacle()
    {
        // 비활성화되고 시작 지점으로 이동
        gameObject.SetActive(false);
        transform.position = tutorialController.startPosition.position;
    }
}
