using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player") != null)
        {
            controller = GameObject.Find("Player").GetComponent<PlayerController>();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "obstacle" && controller.isAnim == true)
        {
            if (col.gameObject.GetComponent<Obstacle>() == null)
            {
                col.gameObject.GetComponent<ObstacleArrow>().ResetObstacle();
            }
            else
            {
                col.gameObject.GetComponent<Obstacle>().ResetObstacle();
            }
            GameManager.Instance.IncreaseScore(1);
        }
    }
}
