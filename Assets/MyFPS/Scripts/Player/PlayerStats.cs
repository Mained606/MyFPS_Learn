using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace MyFPS
{

    //퍼즐 아이템 획득 여부

    public enum PuzzleKey
    {
        ROOM01_KEY,
        LEFTEYE_KEY,
        RIGHTEYE_KEY,
        MAX_KEY //퍼즐 아이템 갯수
    }

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
        private bool[] puzzleKeys;

        //프로퍼티로 히든 키 조건 추가
        // [SerializeField] private bool hiddenKey;
        // public bool HiddenKey
        // {
        //     get { return hiddenKey; }
        //     set { hiddenKey = value; }
        // }

        //[SerializeField] private GameObject pauseUI;
        ////토글
        //private bool uiCheck = false;
        
        #endregion

        void Start()
        {
            AmmoCount = 0;
            puzzleKeys = new bool[(int)PuzzleKey.MAX_KEY];
        }

        //void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.P))
        //    {
        //        Toggle();
        //    }
        //}

        //void Toggle()
        //{
        //    uiCheck = !uiCheck;
        //    pauseUI.SetActive(uiCheck);
        //}

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

        //퍼즐 아이템 획득
        public void AcquirePuzzleItem(PuzzleKey key)
        {
            puzzleKeys[(int)key] = true;
        }

        //프로퍼티 사용시 AddKey
        // public bool AddKey(bool amount)
        // {
        //     HiddenKey = amount;
        //     return HiddenKey;
        // }

        //퍼즐 아이템 소지 여부
        public bool HasPuzzleItem(PuzzleKey key)
        {
            return puzzleKeys[(int)key];
        }




    }

}
