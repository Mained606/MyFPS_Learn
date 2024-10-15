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

        public AudioSource pistolShot;
        // public Transform theCamera;
        public Transform firePoint;

        //총알 발사 속도
        [SerializeField]private float fireDelay = 0.5f;
        private bool isFire = false;


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
                Debug.Log(hit.transform.name);
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
