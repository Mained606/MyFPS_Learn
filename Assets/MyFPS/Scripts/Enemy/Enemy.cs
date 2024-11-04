using UnityEngine;
using UnityEngine.AI;

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
        private NavMeshAgent agent;

        public EnemyState CurrentState { get; private set; }
        private EnemyState beforeState;

        [SerializeField] private float maxHealth = 100f;
        private float currentHealth;

        private bool IsDeath = false;

        [SerializeField] private float attackRange = 1.5f;
        [SerializeField] private float attackDamage = 5f;

        // 패트롤 포인트
        public Transform[] wayPoints;
        private int nowWayPoint = 0;

        private Vector3 startPosition;

        // 적 감지
        private bool isAiming;
        public bool IsAiming
        {
            get { return isAiming; }
            private set { isAiming = value; }
        }
        [SerializeField] private float chaseRange = 20f;
        #endregion

        void Start()
        {
            // 컴포넌트 및 변수 초기화
            thePlayer = GameObject.Find("Player").transform;
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();

            currentHealth = maxHealth;
            startPosition = transform.position;
            nowWayPoint = 0;

            // 웨이포인트에 따라 초기 상태 설정
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

            float distance = Vector3.Distance(thePlayer.transform.position, this.gameObject.transform.position);

            // 추적 범위 내에 플레이어가 있으면 추적 상태로 변경
            if (chaseRange > 0)
            {
                IsAiming = distance <= chaseRange;
            }

            // 공격 범위 내에 플레이어가 있으면 공격 상태로 변경
            if (distance <= attackRange)
            {
                SetState(EnemyState.E_Attack);
                agent.SetDestination(this.transform.position);
            }

            // 추적 범위 내에 플레이어가 있으면 추적 상태로 변경
            else if (chaseRange > 0)
            {
                if(IsAiming)
                {
                    SetState(EnemyState.E_Chase);
                }
            }

            // 상태에 따른 동작 설정
            switch(CurrentState)
            {
                case EnemyState.E_Idle:
                    break;
                case EnemyState.E_Walk:
                    // 목적지 도착 여부 확인
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

                    // 트리거 사용하지 않고 범위에 플레이어가 들어올 때만 Chase 상태로 변경하도록 하는 코드
                    // if(chaseRange > 0 && !IsAiming)
                    // {
                    //     GoStartPosition();
                    //     return;
                    // }

                    //플레이어 위치 업데이트
                    agent.SetDestination(thePlayer.position);

                    break;                                        
            }
        }

        public void SetState(EnemyState newState)
        {
            if (IsDeath || CurrentState == newState)
                return;

            beforeState = CurrentState;
            CurrentState = newState;

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

            // 에이전트 경로 초기화
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
            SetState(EnemyState.E_Death);
            IsDeath = true;
            transform.GetComponent<BoxCollider>().enabled = false;
            Destroy(this.gameObject, 3f); // 3초 후 적 삭제
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

        public void GoStartPosition()
        {
            if(IsDeath)
                return;

            SetState(EnemyState.E_Walk);
            nowWayPoint = 0;
            agent.SetDestination(startPosition);
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseRange);
        }
    }
}
// ==================================================================================
// 트리거 사용하지 않고 범위에 플레이어가 들어올 때만 Chase 상태로 변경하도록 하는 코드
// if(distance <= chaseRange)
// {
//    SetState(EnemyState.E_Chase);
// }
// else
// {
//    SetState(EnemyState.E_Walk);
// }
// ==================================================================================
