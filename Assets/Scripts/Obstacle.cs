using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private ObstacleController obstacleCotroller;
    public float moveSpeed = 5f;   // �̵� �ӵ�

    private void Start()
    {
        obstacleCotroller = GameObject.Find("ObstacleController").GetComponent<ObstacleController>();
    }
    void Update()
    {
        // ��ֹ��� ���� ������ �����ϸ� �ʱ�ȭ
        if (Vector3.Distance(transform.position, obstacleCotroller.endPosition.position) < 0.1f)
        {
            ResetObstacle();
        }
        else
        {
            MoveToDestination();
        }
    }
    //��ǥ���� �ð��� ���� �̵�
    private void MoveToDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position, obstacleCotroller.endPosition.position, moveSpeed * Time.deltaTime);
    }
    // ��ֹ��� endPoint �����ϸ� ��Ȱ��ȭ �� ���� ��ġ�� �ʱ�ȭ
    public void ResetObstacle()
    {
        // ��Ȱ��ȭ�ǰ� ���� �������� �̵�
        gameObject.SetActive(false);
        transform.position = obstacleCotroller.startPosition.position;
    }
}
