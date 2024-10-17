using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyFPS
{
    public class BackgorundUI : MonoBehaviour
    {
        public GameObject[] images;

        private int previousAmmoCount = -1;

        void Update()
        {
            int ammoCount = PlayerStats.Instance.AmmoCount;

            //탄약 수에 변동이 있을 때만 업데이트 되도록 수정
            if(ammoCount != previousAmmoCount)
            {
                //전체 이미지 비활성화
                foreach (var image in images)
                {
                    image.SetActive(false);
                }

                //탄약 수에 맞춰 이미지 활성화
                for(int i = 0; i < ammoCount && i < images.Length; i++)
                {
                    images[i].SetActive(true);
                }

                //이전 탄약 수 업데이트
                previousAmmoCount = ammoCount;
            }

        }
    }

}
