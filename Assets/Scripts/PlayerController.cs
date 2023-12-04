using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float currentTime = 0;
    Rigidbody rigid;
    public float jumpPower = 50.0f;
    public bool isAnim = false;
    bool isJumping = false;
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
            if(!isJumping)
            {
                rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                isJumping = true;
            }
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = false;
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