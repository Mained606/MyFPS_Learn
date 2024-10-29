using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

namespace MyFPS
{
    public enum EnemyState
    {
        E_Idle,
        E_Walk,
        E_Attack,
        E_Death,
        E_Chase
    }
    public class Enemy : MonoBehaviour, IDamageable
    {
        #region Variables
        private Transform thePlayer;
        private Animator animator;
        private UnityEngine.AI.NavMeshAgent agent;

        private EnemyState currentState;
        private EnemyState beforeState;

        [SerializeField] private float maxHealth = 100f;
        private float currentHealth;

        private bool IsDeath = false;

        [SerializeField] private float attackRange = 1.5f;
        [SerializeField] private float attackDamage = 5f;

        //패트롤
        public Transform[] wayPoints;
        private int nowWayPoint = 0;

        private Vector3 startPosition;
        #endregion

        void Start()
        {
            thePlayer = GameObject.Find("Player").transform;
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();

            currentHealth = maxHealth;
            startPosition = transform.position;
            nowWayPoint = 0;

            if(wayPoints.Length > 0)
            {
                SetState(EnemyState.E_Walk);
                GoNextPoint();
            }
            else
            {
                SetState(EnemyState.E_Idle);
            }
            
        }

        void Update()
        {
            if(IsDeath)
                return;
            // Vector3 dir = thePlayer.transform.position - this.gameObject.transform.position;

            float distance = Vector3.Distance(thePlayer.transform.position, this.gameObject.transform.position);
            if(distance <= attackRange)
            {
                SetState(EnemyState.E_Attack);
            }

            switch(currentState)
            {
                case EnemyState.E_Idle:
                    break;
                case EnemyState.E_Walk:
                    //도착판정
                    if(agent.remainingDistance <= 0.2f)
                    {
                        if(wayPoints.Length > 0)
                        {
                            GoNextPoint();
                        }
                        else
                        {
                            SetState(EnemyState.E_Idle);
                        }
                    }
                    break;

                case EnemyState.E_Attack:
                    transform.LookAt(thePlayer.position);
                    if(distance > attackRange)
                    {
                        SetState(EnemyState.E_Chase);
                    }
                    break;
                case EnemyState.E_Death:
                    break;
                case EnemyState.E_Chase:
                    //플레이어 위치 업데이트
                    agent.SetDestination(thePlayer.position);
                    break;                                        
            }
        }

        public void SetState(EnemyState newState)
        {
            if(currentState == newState)
                return;
            //이전 상태 저장
            beforeState = currentState;
            //현재 상태 저장
            currentState = newState;
            //애니메이션 상태 변경
            if(newState == EnemyState.E_Chase)
            {
                animator.SetInteger("EnemyState", 1);
                animator.SetLayerWeight(1, 1f);
            }
            else
            {
                animator.SetInteger("EnemyState", (int)newState);
                animator.SetLayerWeight(1, 0f);
            }

            //Agent 초기화
            agent.ResetPath();
        }

        private void Attack()
        {
            IDamageable damageable = thePlayer.GetComponent<IDamageable>();
            if(damageable != null)
            {
                damageable.TakeDamage(attackDamage);
            }
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log("currentHealth: " + currentHealth);
            if(currentHealth <= 0 && !IsDeath)
            {
                Die();
            }
        }

        private void Die()
        {
            IsDeath = true;

            SetState(EnemyState.E_Death);

            transform.GetComponent<BoxCollider>().enabled = false;
        }

        private void GoNextPoint()
        {
            nowWayPoint++;
            if(nowWayPoint >= wayPoints.Length)
            {
                nowWayPoint = 0;
            }
            agent.SetDestination(wayPoints[nowWayPoint].position);
        }

    }

}
