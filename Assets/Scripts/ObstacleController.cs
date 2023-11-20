using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Transform startPosition; // ��ֹ� ��Ÿ���� ����
    public Transform endPosition; // ��ֹ� ������� ����
    public Transform middlePosition;
    public int bpm = 0;
    double currentTime = 0d;

    public ObstaclePool obstaclePool;

    void Start()
    {

    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime >= 60d / bpm)
        {
            ActivateObstacle();

            currentTime -= 60d / bpm;
        }
    }

    void ActivateObstacle()
    {
        // �����ϰ� ��ֹ� ���� ����
        ObstaclePool.ObstacleType randomType = (ObstaclePool.ObstacleType)Random.Range(0, System.Enum.GetValues(typeof(ObstaclePool.ObstacleType)).Length);

        GameObject obstacle = obstaclePool.GetPooledObstacle(randomType);

        // ��ֹ� Ȱ��ȭ
        if (obstacle != null)
        {
            obstacle.SetActive(true);
            obstacle.transform.position = startPosition.position;
        }
        else
        {
            Debug.LogError("�ش� Ÿ�� ��ֹ� ������Ʈ�� Ǯ�� ���� " + randomType);
        }
    }

}
