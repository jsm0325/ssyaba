using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public TutorialObstacle tutorialController;
    public float moveSpeed = 5f;   // �̵� �ӵ�

    private void Start()
    {
        tutorialController = GameObject.Find("ObstacleController").GetComponent<TutorialObstacle>();
    }
    void Update()
    {
        // ��ֹ��� ���� ������ �����ϸ� �ʱ�ȭ
        if (Vector3.Distance(transform.position, tutorialController.endPosition.position) < 0.1f)
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
        transform.position = Vector3.MoveTowards(transform.position, tutorialController.endPosition.position, moveSpeed * Time.deltaTime);
    }
    // ��ֹ��� endPoint �����ϸ� ��Ȱ��ȭ �� ���� ��ġ�� �ʱ�ȭ
    public void ResetObstacle()
    {
        // ��Ȱ��ȭ�ǰ� ���� �������� �̵�
        gameObject.SetActive(false);
        transform.position = tutorialController.startPosition.position;
    }
}
