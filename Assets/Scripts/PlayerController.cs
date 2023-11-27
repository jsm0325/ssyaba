using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float currentTime = 0;
    public GameObject judge;
    Rigidbody rigid;
    public float jumpPower = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        //idle 달리는 애니메이션
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            judge.SetActive(true);
            currentTime += Time.deltaTime;
            if (currentTime > 0.1f)
            {
                judge.SetActive(false);
                currentTime = 0;
            }
            //막기 애니메이션
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            judge.SetActive(true);
            currentTime += Time.deltaTime;
            if (currentTime > 0.1f)
            {
                judge.SetActive(false);
                currentTime = 0;
            }
            //쳐내기 애니메이션
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //점프 애니메이션
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            GameManager.Instance.DecreaseHp(1);
        }
    }
}