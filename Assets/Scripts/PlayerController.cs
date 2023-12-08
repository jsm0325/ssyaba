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

    private Animator anim;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        judge = GameObject.Find("judge");
        judge.SetActive(false);
        anim = GetComponent<Animator>();
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
                anim.SetInteger("attack", 1);
            }
            //막기 애니메이션
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (!isAnim) 
            {
                judge.SetActive(true);
                isAnim = true;
                anim.SetInteger("attack", 2);
            }
            //쳐내기 애니메이션
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!isJumping)
            {
                rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                isJumping = true;
                anim.SetBool("jump", true);
            }
        }
        if (isAnim == true)
        {
            currentTime += Time.deltaTime;
            if (currentTime > 0.1f)
            {
                isAnim = false;
                judge.SetActive(false);
                anim.SetInteger("attack", 0);
                currentTime = 0;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "obstacle")
        {
            col.gameObject.GetComponent<Obstacle>().ResetObstacle();
            anim.SetTrigger("hit");
            GameManager.Instance.DecreaseHp(1);
        } else if (col.gameObject.tag == "tobstacle")
        {
            col.gameObject.GetComponent<Tutorial>().ResetObstacle();
        }
    }

}