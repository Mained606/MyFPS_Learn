using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class PistolShoot : MonoBehaviour
    {
        #region Variables
        private Animator animator;
        public ParticleSystem muzzleEffect;
        public GameObject hitImpactPrefab;

        public AudioSource pistolShot;
        public Transform theCamera;  
        public Transform firePoint;

        //총알 발사 속도
        [SerializeField]private float fireDelay = 0.5f;

        [SerializeField] private float damage = 5f;
        private bool isFire = false;

        [SerializeField] private float impactForce = 2f;


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
                if(PlayerStats.Instance.UseAmmo(1) == true)
                {
                    StartCoroutine(Shoot());
                }
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

                Debug.Log(hit.transform.name);  

                //총알 탄피 이펙트 생성
                GameObject impactGO = Instantiate(hitImpactPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);

                // 적 넉백 효과 적용
                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }

                //적에게 데미지를 준다
                IDamageable damageable = hit.transform.GetComponent<IDamageable>();
                if(damageable != null)
                {
                    damageable.TakeDamage(damage);
                }

                // RobotController robotController = hit.transform.GetComponent<RobotController>();

                // if(robotController != null)
                // {
                //     robotController.TakeDamage(damage);
                //     Debug.Log(robotController.currentHealth);
                // }
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
