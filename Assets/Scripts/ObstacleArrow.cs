using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleArrow : MonoBehaviour
{
    private ObstacleController obstacleCotroller;
    public float _duration;

    private void Awake()
    {
        obstacleCotroller = GameObject.Find("ObstacleController").GetComponent<ObstacleController>();
    }

    private void OnEnable()
    {
        StartCoroutine(COR_BezierCurves());
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

            Vector3 p4 = Vector3.Lerp(obstacleCotroller.startPosition.position, obstacleCotroller.middlePosition.position, time);
            Vector3 p5 = Vector3.Lerp(obstacleCotroller.middlePosition.position, obstacleCotroller.endPosition.position, time);
            transform.position = Vector3.Lerp(p4, p5, time);

            Vector3 direction = p5 - p4;
            transform.rotation = Quaternion.LookRotation(direction.normalized);
            transform.rotation *= Quaternion.Euler(90f, 0f, 0f);

            time += Time.deltaTime / duration;

            yield return null;
        }
    }


    void Update()
    {
        // 장애물이 도착 지점에 도달하면 초기화
        if (Vector3.Distance(transform.position, obstacleCotroller.endPosition.position) < 0.1f)
        {
            ResetObstacle();
        }
    }

    // 장애물이 endPoint 도착하면 비활성화 후 원래 위치로 초기화
    void ResetObstacle()
    {
        // 비활성화되고 시작 지점으로 이동
        gameObject.SetActive(false);
        transform.position = obstacleCotroller.startPosition.position;
    }
}
