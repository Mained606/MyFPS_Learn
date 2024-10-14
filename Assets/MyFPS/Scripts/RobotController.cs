using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class RobotController : MonoBehaviour
    {
        Animator animator;
        public GameObject theRobot;  

        void Awake()
        {
            animator = theRobot.GetComponentInChildren<Animator>();

        }

        void OnEnable()
        {
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
            Debug.Log("RobotController.PlaySequence()");
            yield return new WaitForSeconds(2f);
            animator.SetInteger("RobotState", 1);
        }
    }

}
