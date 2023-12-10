using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialJudge : MonoBehaviour
{
    PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            controller = GameObject.Find("Player").GetComponent<PlayerController>();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "tobstacle" && controller.isAnim == true)
        {
            if (col.gameObject.GetComponent<Tutorial>() == null)
            {
                col.gameObject.GetComponent<TutorialObstacleArrow>().ResetObstacle();
            }
            else
            {
                col.gameObject.GetComponent<Tutorial>().ResetObstacle();
            }
        }
    }
}
