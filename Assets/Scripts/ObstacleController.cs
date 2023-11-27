using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using static ObstaclePool;

public class ObstacleController : MonoBehaviour
{
    public Transform startPosition; // 장애물 나타나는 지점
    public Transform endPosition; // 장애물 사라지는 지점
    public Transform middlePosition;
    public float bpm = 96.0f;
    double currentTime = 0d;

    public ObstaclePool obstaclePool;

    float[] drumbeatA = { 1, 1, 1, 1, 1, 1, 0.5f, 0.5f, 1, 1, 1, 1, 1, 1, 1, 0.5f, 0.5f, 1 };
    float[] drumbeatB = { 0.5f, 0.5f, 0.5f, 0.5f, 0.25f, 0.25f, 0.25f, 0.25f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.25f, 0.25f, 0.25f, 0.25f, 0.5f, 0.5f,
    0.5f, 0.5f, 0.5f, 0.5f, 0.25f, 0.25f, 0.25f, 0.25f, 0.5f, 0.5f, 0.5f, 0.5f, 0.25f, 0.25f, 0.25f, 0.25f, 0.5f, 0.5f, 1 };
    string[] drumSeq = { "a", "b", "a", "b", "b" };
    int i = 0;
    int j = 0;
    int k = 0;
    void Start()
    {

    }

    private void Update()
    {
        /*currentTime += Time.deltaTime;

        if (currentTime >= 60d / bpm)
        {
            //ActivateObstacle();

            currentTime -= 60d / bpm;
        }*/

        float beat = bpm / 60.0f;

        if (drumSeq[i] == "a")
        {
            currentTime += Time.deltaTime;
            if (currentTime > beat * drumbeatA[j])
            {
                ActivateRock();
                j++;
                currentTime = 0;
            }
            if (j >= drumbeatA.Length)
            {
                j = 0;
                i++;
            }
        }
        else
        {
            currentTime += Time.deltaTime;
            if (currentTime > beat * drumbeatB[k])
            {
                ActivateRock();
                k++;
                currentTime = 0;
            }
            if (k >= drumbeatB.Length)
            {
                k = 0;
                i++;
            }
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

    void ActivateRock()
    {
        GameObject rock = obstaclePool.GetPooledObstacle(ObstacleType.Rock);
        if (rock != null)
        {
            rock.SetActive(true);
            rock.transform.position = startPosition.position;
        }
        else
        {
            Debug.LogError("해당 타입 장애물 오브젝트가 풀에 없음 " + rock);
        }
    }
}
