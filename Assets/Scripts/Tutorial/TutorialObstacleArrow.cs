using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialObstacleArrow : MonoBehaviour
{
    public TutorialObstacle tutorialController;
    public float _duration;
    private Vector3 middle;
    private void Awake()
    {
        tutorialController = GameObject.Find("ObstacleController").GetComponent<TutorialObstacle>();
    }

    private void OnEnable()
    {
        middle = tutorialController.middlePosition.position;
        _duration = CaculateDistance();
        StartCoroutine(COR_BezierCurves(_duration));
    }
    IEnumerator COR_BezierCurves(float duration = 1.0f)
    {
        float time = 0f;

        while (true)
        {
            if (time > 1f)
            {
                time = 0f;
            }

            Vector3 p4 = Vector3.Lerp(tutorialController.startPosition.position, middle, time);
            Vector3 p5 = Vector3.Lerp(middle, tutorialController.endPosition.position, time);
            transform.position = Vector3.Lerp(p4, p5, time);

            Vector3 direction = p5 - p4;
            transform.rotation = Quaternion.LookRotation(direction.normalized);
            transform.rotation *= Quaternion.Euler(0f, -90f, 0f);

            time += Time.deltaTime / duration;

            yield return null;
        }
    }


    void Update()
    {
        // ��ֹ��� ���� ������ �����ϸ� �ʱ�ȭ
        if (Vector3.Distance(transform.position, tutorialController.endPosition.position) < 0.1f)
        {
            ResetObstacle();
        }
    }

    // ��ֹ��� endPoint �����ϸ� ��Ȱ��ȭ �� ���� ��ġ�� �ʱ�ȭ
    public void ResetObstacle()
    {
        // ��Ȱ��ȭ�ǰ� ���� �������� �̵�
        gameObject.SetActive(false);
        transform.position = tutorialController.startPosition.position;
    }

    float CaculateDistance()
    {
        return Vector3.Distance(tutorialController.startPosition.position, tutorialController.endPosition.position)/10f;

    }
}
