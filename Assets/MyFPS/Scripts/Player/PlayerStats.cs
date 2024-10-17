using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace MyFPS
{
    //플레이어의 속성값을 관리하는 (싱글톤, DontDestroyOnLoad) 클래스 .. Ammo
    public class PlayerStats : PersistentSingleton<PlayerStats>
    {

        #region Variables
        [SerializeField] private int ammoCount;
        public int AmmoCount
        {
            get { return ammoCount; }
            set { ammoCount = value; }
        }
        
        #endregion

        void Start()
        {
            AmmoCount = 0;
        }

        public void AddAmmo(int amount)
        {
            AmmoCount += amount;
        }

        public bool UseAmmo(int amount)
        {
            //소지 갯수 체크
            if(AmmoCount < amount)
            {
                Debug.Log("총알이 부족합니다.");
                return false;
            }
            else
            {
                AmmoCount -= amount;
                return true;
            }
        }

        public void ResetAmmo()
        {
            AmmoCount = 0;
        }




    }

}
