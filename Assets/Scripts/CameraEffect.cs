using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraEffect : MonoBehaviour
{
    public float ShakeAmount; // 카메라 흔들리는 정도

    private float ShakeTime = 1f; // 카메라 흔들리는 시간
    Vector3 initialPosition;
    public Image damageEffect;
    void Start()
    {
        initialPosition = this.transform.position;
        StartCoroutine(FadeDamageEffect());
        
    }

    void Update()
    {
        if (ShakeTime >0)
        {
            transform.position = Random.insideUnitSphere * ShakeAmount + initialPosition;
            ShakeTime -= Time.deltaTime;
        }
        else
        {
            ShakeTime = 0.0f;
            transform.position = initialPosition;
        }
    }
    public void ShakeTimeSet(float time)
    {
        ShakeTime = time;
    }

    IEnumerator FadeDamageEffect()
    {
        Color color = damageEffect.color;
        for (float alpha = 0.6f; alpha >= -0.1f; alpha -= 0.2f)
        {
            color.a = alpha;
            damageEffect.color = color;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
