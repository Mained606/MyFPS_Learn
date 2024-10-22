using MyFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class ShootingTest : MonoBehaviour
    {
        #region Variables
        private Animator animator;
        public ParticleSystem muzzleEffect;

        public AudioSource pistolShot;
        //public Transform theCamera;  
        public Transform firePoint;

        //총알 발사 속도
        [SerializeField]private float fireDelay = 0.5f;

        [SerializeField] private float damage = 5f;
        private bool isFire = false;

        //탄착 임팩트 효과
        public GameObject hitImpactPrefab;
        [SerializeField] private float impactForce = 10f;
        #endregion

        void Awake()
        {
            //참조
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            //마우스 왼쪽 버튼 클릭 시 발사
            if(Input.GetButtonDown("Fire") && !isFire)
            {
                StartCoroutine(Shoot());
            }

        }

        IEnumerator Shoot()
        {
            isFire = true;
            //내 앞에 100 안에 적이 있으면 적에게 데미지를 준다
            float maxDistance = 100f;
            RaycastHit hit;
            if(Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance))
            {
                //적에게 데미지를 준다.
                Debug.Log(hit.transform.name);

                //임펙트 효과
                GameObject EffectGo = Instantiate(hitImpactPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(EffectGo, 2f);

                if(hit.rigidbody != null)
                {
                    //Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                    //RaycastHit 구조체는 레이캐스트 결과에 대한 정보를 포함하고 있으며
                    //여기에는 hit.rigidbody라는 프로퍼티가 이미 포함되어 있다.

                    hit.rigidbody.AddForce(-hit.normal * impactForce, ForceMode.Impulse);
                }
                

                IDamageable damageable = hit.transform.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeDamage(damage);

                    
                }
            }

        
            //애니메이션 재생
            animator.SetTrigger("Fire");

            pistolShot.Play();
            muzzleEffect.gameObject.SetActive(true);
            //총구 이펙트 재생
            muzzleEffect.Play();


            yield return new WaitForSeconds(fireDelay);
            muzzleEffect.Stop();
            muzzleEffect.gameObject.SetActive(false);

            isFire = false;

        }

        void OnDrawGizmosSelected()
        {
            // Gizmos.color = Color.red;
            // Gizmos.DrawRay(transform.position, transform.forward * distanceFormTarget);

            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance);

            if (isHit)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawRay(firePoint.position, firePoint.forward * hit.distance);

            }
            else
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * maxDistance);
            }
        }
    }
}
