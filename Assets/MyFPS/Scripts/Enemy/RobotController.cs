using System.Collections;
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

    public class RobotController : MonoBehaviour, IDamageable
    {
        #region Variables
        private Animator animator;
        private RobotState currentState;
        private RobotState beforeState;

        [SerializeField] private float startHealth = 20;
        public float currentHealth;
        [SerializeField] private float attackDamage = 5f;
        [SerializeField] private float attackRange = 1.5f;
        [SerializeField] private float attackDelay = 2f;
        [SerializeField] private float moveSpeed = 3f;
        
        //===============================================
        // 다른 방법 시도 후 삭제된 코드
        // public GameObject theRobot;  
        // private bool isMoving = false;
        // private bool isAttacking = false;
        //===============================================

        public GameObject target;
        private bool isDead = false;
        public float attackDelayTime;

        //배경음
        public AudioSource bgm01;
        public AudioSource bgm02;
        #endregion

        void Awake()
        {
            animator = GetComponent<Animator>();
            SetState(RobotState.R_Idle);

            currentHealth = startHealth;
            isDead = false;
            attackDelayTime = attackDelay;

            //===============================================
            // 다른 방법 시도 후 삭제된 코드
            // currentState = RobotState.R_Idle;
            // animator.SetInteger("RobotState", 0);

            // currentState = RobotState.R_Walk;
            // animator.SetInteger("RobotState", 1);
            //===============================================
        }
        
        public void SetState(RobotState newState)
        {
            if(currentState == newState)
                return;

            beforeState = currentState;
            currentState = newState;
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
            yield return new WaitForSeconds(2f);

            bgm02.Stop();
            bgm01.Play();

            transform.GetComponent<CapsuleCollider>().enabled = false;
        }

        //===============================================
        // 다른 방법 시도 후 삭제된 코드
        // private void AttackTimer()
        // {
        //     if(attackDelayTime <= 0)
        //     {
        //         Attack();
        //         attackDelayTime = attackDelay;
        //     }

        //     attackDelayTime -= Time.deltaTime;
        // }
        //===============================================

        private void Attack()
        {
            IDamageable damageable = target.GetComponent<IDamageable>();
            if(damageable != null)
            {
                damageable.TakeDamage(attackDamage);
            }

            //===============================================
            // 다른 방법 시도 후 삭제된 코드
            // PlayerController player = target.GetComponent<PlayerController>();
            // if(player != null)
            // {
            //     player.TakeDamage(attackDamage);
            // }
            //===============================================
        }

        //===============================================
        // 다른 방법 시도 후 삭제된 코드
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
        //===============================================

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
                case RobotState.R_Walk:
                    transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World); 
                    transform.LookAt(target.transform);
                    if(distance <= attackRange)
                    {
                        SetState(RobotState.R_Attack);
                    }
                    break;
                case RobotState.R_Attack:
                    if(distance > attackRange)
                    {
                        SetState(RobotState.R_Walk);
                    }
                    // AttackTimer();
                    break;
                // case RobotState.R_Death: //죽는다.
                //     break;
            }

            //===============================================
            // 다른 방법 시도 후 삭제된 코드
            // if (isMoving)
            // {
            //     Move();
            // }
            //===============================================
        }

        //===============================================
        // 다른 방법 시도 후 삭제된 코드
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
        //
    
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
        //===============================================
    }
}