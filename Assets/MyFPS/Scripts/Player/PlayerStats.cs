using UnityEngine;

namespace MyFPS
{
    //퍼즐 아이템 획득 여부
    public enum PuzzleKey
    {
        ROOM01_KEY,
        LEFTEYE_KEY,
        RIGHTEYE_KEY,
        MAX_KEY // 최대 퍼즐 아이템 갯수
    }

    //플레이어의 속성값을 관리하는 (싱글톤, DontDestroyOnLoad) 클래스 .. Ammo
    public class PlayerStats : PersistentSingleton<PlayerStats>
    {
        #region Variables
        // 저장된 씬 번호
        private int currentScene;
        public int CurrentScene
        {
            get { return currentScene; }
            set { currentScene = value; }
        }

        //현재 씬 번호
        private int nowSceneNumber;
        public int NowSceneNumber
        {
            get { return nowSceneNumber; }
            set { nowSceneNumber = value; }
        }

        //총알 갯수
        [SerializeField] private int ammoCount;
        public int AmmoCount
        {
            get { return ammoCount; }
            set { ammoCount = value; }
        }

        //무기 소지 여부
        [SerializeField] private bool hasWeapon;
        public bool HasWeapon
        {
            get { return hasWeapon; }
            set { hasWeapon = value; }
        }

        //게임 퍼즐 아이템 키
        private bool[] puzzleKeys;

        // ===============================================
        // 다른 방법 시도 후 삭제한 코드
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
        // ===============================================
        #endregion

        void Start()
        {
            // AmmoCount = 0;
            puzzleKeys = new bool[(int)PuzzleKey.MAX_KEY];
        }

        public void PlayerStatInit(PlayData playData)
        {   
            if(playData != null)
            {
                //게임 플레이 데이터가 있으면 세팅
                CurrentScene = playData.currentScene;
                AmmoCount = playData.ammoCount;
                HasWeapon = playData.hasWeapon;
            }
            else
            {
                //게임 플레이 데이터가 없으면 초기화
                CurrentScene = 0;
                AmmoCount = 0;
                HasWeapon = false;
                // Debug.Log("No save data");
            }

        }

        // ===============================================
        // 다른 방법 시도 후 삭제한 코드
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
        // ===============================================

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

        // ===============================================
        // 다른 방법 시도 후 삭제한 코드
        //프로퍼티 사용시 AddKey
        // public bool AddKey(bool amount)
        // {
        //     HiddenKey = amount;
        //     return HiddenKey;
        // }
        // ===============================================

        //퍼즐 아이템 소지 여부
        public bool HasPuzzleItem(PuzzleKey key)
        {
            return puzzleKeys[(int)key];
        }

        //무기 획득 셋팅
        public void SetHasWeapon(bool value)
        {
            HasWeapon = value;
        }
    }
}
