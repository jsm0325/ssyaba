using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float currentTime = 0;
    Rigidbody rigid;
    public float jumpPower = 3.0f;
    public bool isAnim = false;
    public GameObject judge;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        judge = GameObject.Find("judge");
        judge.SetActive(false);
        //idle 달리는 애니메이션
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (!isAnim)
            {
                judge.SetActive(true);
                isAnim = true;
            }
            //막기 애니메이션
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (!isAnim) 
            {
                judge.SetActive(true);
                isAnim = true;
            }
            //쳐내기 애니메이션
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //점프 애니메이션
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        if (isAnim == true)
        {
            currentTime += Time.deltaTime;
            if (currentTime > 0.1f)
            {
                isAnim = false;
                judge.SetActive(false);
                currentTime = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "obstacle")
        {
            col.gameObject.GetComponent<Obstacle>().ResetObstacle();
            GameManager.Instance.DecreaseHp(1);
        }
    }

}