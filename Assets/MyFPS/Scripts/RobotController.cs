using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

namespace MyFPS
{
    public enum RobotState
    {
        R_Idle,
        R_Walk,
        R_Attack,
        R_Death
    }
    public class RobotController : MonoBehaviour
    {
        private Animator animator;
        //로봇 현재 상태
        private RobotState currentState;
        //로봇 이전 상태 
        private RobotState beforeState;
        //체력
         [SerializeField] private float startHealth = 20;
        // public GameObject theRobot;  
        // public Transform target;
        // private float moveSpeed = 3f;
        // private bool isMoving = false;
        // private bool isAttacking = false;
        void Awake()
        {
            //참조
            animator = GetComponent<Animator>();
            //초기 상태 설정
            SetState(RobotState.R_Idle);

            // currentState = RobotState.R_Idle;
            // animator.SetInteger("RobotState", 0);

            // currentState = RobotState.R_Walk;
            // animator.SetInteger("RobotState", 1);
        }

        private void SetState(RobotState newState)
        {
            if(currentState == newState)
                return;
            //이전 상태 저장
            beforeState = currentState;
            //현재 상태 저장
            currentState = newState;
            //애니메이션 상태 변경
            animator.SetInteger("RobotState", (int)newState);
        }

//         void OnEnable()
//         {
//             StartCoroutine(PlaySequence());
//         }

//         IEnumerator PlaySequence()
//         {
//             // Debug.Log("RobotController.PlaySequence()");
//             yield return new WaitForSeconds(2f);
//             animator.SetInteger("RobotState", 1);
//             isMoving = true;
//         }
        
//         void Update()
//         {
//             if (isMoving && !isAttacking)
//             {
//                 Move();
//             }
//         }

//         void Move()
//         {
//             if(isMoving)
//             {
//                 Vector3 dir = target.position - this.gameObject.transform.position;
//                 Quaternion quaternion = Quaternion.LookRotation(dir);
//                 transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, 0.1f);
//                 transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World); 

//                 if(dir.magnitude < 3f)
//                 {
//                     StartCoroutine(Attack());
//                 }
//             }
//         }

//         IEnumerator Attack()
//         {
//             isMoving = false;
//             isAttacking = true;
//             animator.SetInteger("RobotState", 2);
//             yield return new WaitForSeconds(2f);
//             isAttacking = false;
//             StartCoroutine(PlaySequence());
//         }
//     }

// }
    }
}