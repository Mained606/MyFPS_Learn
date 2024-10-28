using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class PickupItem : MonoBehaviour
    {
        #region Variables
        // [SerializeField] private int giveAmmoCount = 7;
        [SerializeField] private float verticalBobFrequency = 1f; //이동 속도
        [SerializeField] private float bobingAmount = 1f; //이동 거리
        [SerializeField] private float rotateSpeed = 360f;

        private Vector3 startPosition;
        #endregion

        void Start()
        {
            startPosition = transform.position;
        }

        void Update()
        {
            //위 아래로 흔들림(진동)
            float bobingAnimationPhase = Mathf.Sin(Time.time * verticalBobFrequency) * bobingAmount;
            transform.position = startPosition + Vector3.up * bobingAnimationPhase;

            //회전
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            //플레이어 체크
            if(other.tag == "Player")
            {
                //아이템 획득
                if(OnPickup() == true)
                {
                    //성공효과, 사운드, 이펙트
                    
                    //킬
                    Destroy(this.gameObject);
                }
            }
        }

        protected virtual bool OnPickup()
        {
            //아이템 획득
            // PlayerStats.Instance.AddAmmo(giveAmmoCount);

            return true;
        }
    }

}
