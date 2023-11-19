using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Transform startPosition; // ��ֹ� ��Ÿ���� ����
    public Transform endPosition; // ��ֹ� ������� ����

    public ObstaclePool obstaclePool;

    void Start()
    {
        // ������ �� 3�ʸ��� ActivateObstacle �Լ��� ȣ��
        InvokeRepeating("ActivateObstacle", 0f, 3f);
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
