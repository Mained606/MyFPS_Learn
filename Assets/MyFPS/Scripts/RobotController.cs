using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        public Animator animator;
        //로봇 현재 상태
        private RobotState currentState;
        //로봇 이전 상태 
        private RobotState beforeState;
        //Enemy Stats
        [SerializeField] private float startHealth = 20;
        public float health;
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private float attackDamage = 5f;
        [SerializeField] private float attackRange = 1.5f;
        [SerializeField] private float attackDelay = 2f;


        // public GameObject theRobot;  
        public Transform target;
        private bool isMoving = false;
        private bool isAttacking = false;
        void Awake()
        {
            //참조
            // animator = GetComponent<Animator>();
            
            //초기 상태 설정
            SetState(RobotState.R_Idle);

            health = startHealth;

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

        public void TakeDamage(float damage)
        {
            health -= damage;
            if(health <= 0)
            {
                StartCoroutine(Die());
            }
        }

        IEnumerator Die()
        {
            SetState(RobotState.R_Death);
            yield return new WaitForSeconds(3f);
            Destroy(this.gameObject);
        }



        void OnEnable()
        {
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
            // Debug.Log("RobotController.PlaySequence()");
            yield return new WaitForSeconds(2f);
            SetState(RobotState.R_Walk);
            isMoving = true;
        }

        
        void Update()
        {
            if (isMoving)
            {
                Move();
            }
        }

        void Move()
        {
            if(isMoving)
            {
                Vector3 dir = target.transform.position - this.gameObject.transform.position;
                Quaternion quaternion = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, 0.1f);
                transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World); 

                if(dir.magnitude < 3f)
                {
                    StartCoroutine(Attack(target));
                }
            }
        }

        IEnumerator Attack(Transform target)
        {
            isAttacking = true;
            isMoving = false;
            SetState(RobotState.R_Attack);

            Vector3 dir = target.transform.position - this.gameObject.transform.position;
            if(dir.magnitude < attackRange)
            {
                PlayerCasting playerCasting = target.GetComponent<Collider>().GetComponent<PlayerCasting>();
            }

            
            yield return new WaitForSeconds(1f);
            isAttacking = false;
            StartCoroutine(PlaySequence());

        }
    }
}