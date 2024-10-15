using System.Collections;
using UnityEngine;

namespace MyFPS
{
    //정면에 있는 충돌체와의 거리 구하기
    public class PlayerCasting : MonoBehaviour
    {

        #region Variables

        // public GameObject doorUi;
        public static float distanceFormTarget;
        [SerializeField] private float toTarget; //거리 숫자 보기(임시)

        public float health = 20f;

        #endregion
        void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                distanceFormTarget = hit.distance;
                toTarget = distanceFormTarget;
            }
            // if (hit.collider.tag == "Door" && distanceFormTarget < 2f)
            // {
            //     doorUi.SetActive(true);
            // }
            // else
            // {
            //     doorUi.SetActive(false);
            // }
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
            Debug.Log("사망하였습니다.");
            Destroy(gameObject);
            yield return null;
        }

        // Gizmo 그리기 : 카메라 위치에서 앞에 충돌체까지 레이저 쏘는 선 그리기
        void OnDrawGizmosSelected()
        {
            // Gizmos.color = Color.red;
            // Gizmos.DrawRay(transform.position, transform.forward * distanceFormTarget);

            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance);

            if (isHit)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawRay(transform.position, transform.forward * hit.distance);

            }
            else
            {
                Gizmos.color = Color.green;
                Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
  
            }
        }
    }

}