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
        private Animator animator;
        //로봇 현재 상태
        private RobotState currentState;
        //로봇 이전 상태 
        private RobotState beforeState;
        //Enemy Stats
        [SerializeField] private float startHealth = 20;
        public float currentHealth;
        [SerializeField] private float attackDamage = 5f;
        [SerializeField] private float attackRange = 1.5f;
        [SerializeField] private float attackDelay = 2f;

        //이동
        [SerializeField] private float moveSpeed = 3f;
        


        // public GameObject theRobot;  
        public GameObject target;
        private bool isMoving = false;
        private bool isAttacking = false;
        private bool isDead = false;

        public float attackDelayTime;
        void Awake()
        {
            //참조
            animator = GetComponent<Animator>();
            
            //초기 상태 설정
            SetState(RobotState.R_Idle);

            currentHealth = startHealth;
            isDead = false;

            attackDelayTime = attackDelay;

            // currentState = RobotState.R_Idle;
            // animator.SetInteger("RobotState", 0);

            // currentState = RobotState.R_Walk;
            // animator.SetInteger("RobotState", 1);

        }
        
        

        public void SetState(RobotState newState)
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
            currentHealth -= damage;
            Debug.Log("currentHealth: " + currentHealth);
            if(currentHealth <= 0 && !isDead)
            {
                StartCoroutine(Die());
            }
        }

        IEnumerator Die()
        {
            isDead = true;
            SetState(RobotState.R_Death);
            yield return new WaitForSeconds(3f);
            Destroy(this.gameObject);
        }

        // private void AttackTimer()
        // {
        //     if(attackDelayTime <= 0)
        //     {
        //         Attack();
        //         attackDelayTime = attackDelay;
        //     }

        //     attackDelayTime -= Time.deltaTime;
        // }

        private void Attack()
        {
            PlayerController player = target.GetComponent<PlayerController>();
            if(player != null)
            {
                player.TakeDamage(attackDamage);
            }
        }



        //오브젝트 활성화 시 실행 걷기 진입.
        // void OnEnable()
        // {
        //     StartCoroutine(PlaySequence());
        // }

        // IEnumerator PlaySequence()
        // {
        //     // Debug.Log("RobotController.PlaySequence()");
        //     yield return new WaitForSeconds(2f);
        //     SetState(RobotState.R_Walk);
        //     isMoving = true;
        // }

        
        void Update()
        {
            if(isDead)
                return;
            Vector3 dir = target.transform.position - this.gameObject.transform.position;
            float distance = Vector3.Distance(target.transform.position, this.gameObject.transform.position);

            //로봇 상태 구현
            switch(currentState)
            {
                case RobotState.R_Idle:
                    break;
                case RobotState.R_Walk: //플레이어를 향해 걷는다.(이동)
                    transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World); 
                    transform.LookAt(target.transform);
                    if(distance <= attackRange)
                    {
                        SetState(RobotState.R_Attack);
                    }
                    break;
                case RobotState.R_Attack: //플레이어를 공격한다.
                    if(distance > attackRange)
                    {
                        SetState(RobotState.R_Walk);
                    }
                    // AttackTimer();
                    break;
                // case RobotState.R_Death: //죽는다.
                //     break;
            }

            // if (isMoving)
            // {
            //     Move();
            // }
        }

        // void Move()
        // {
        //     if(isMoving)
        //     {
        //         Vector3 dir = target.transform.position - this.gameObject.transform.position;
        //         Quaternion quaternion = Quaternion.LookRotation(dir);
        //         transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, 0.1f);
        //         transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World); 

        //         if(dir.magnitude < 3f)
        //         {
        //             StartCoroutine(Attack(target));
        //         }
        //     }
        // }

        // IEnumerator Attack(Transform target)
        // {
        //     isAttacking = true;
        //     isMoving = false;
        //     SetState(RobotState.R_Attack);

        //     Vector3 dir = target.transform.position - this.gameObject.transform.position;
        //     if(dir.magnitude < attackRange)
        //     {
        //         PlayerCasting playerCasting = target.GetComponent<Collider>().GetComponent<PlayerCasting>();
        //     }

            
        //     yield return new WaitForSeconds(1f);
        //     isAttacking = false;
        //     StartCoroutine(PlaySequence());

        // }
    }
}