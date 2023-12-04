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

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        //idle 달리는 애니메이션
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && isAnim == false)
        {
            isAnim = true;
            //막기 애니메이션
        }
        if (Input.GetKeyDown(KeyCode.K) && isAnim == false)
        {
            currentTime += Time.deltaTime;
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
            if (currentTime > 0.25f)
            {
                isAnim = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle" && isAnim == false)
        {
            GameManager.Instance.DecreaseHp(1);
        }
        if (collision.gameObject.tag == "obstacle" && isAnim == true)
        {
            GameObject.Destroy(collision.gameObject);
            GameManager.Instance.IncreaseScore(1);
        }
    }
}