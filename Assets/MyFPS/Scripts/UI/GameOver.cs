using UnityEngine;

namespace MyFPS
{
    public class GameOver : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";
        #endregion

        void Start()
        {
            //마우스 커서 상태 설정
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //페이드 인 효과
            fader.FromFade();
        }

        public void Retry()
        {
            //탄약 수 초기화
            PlayerStats.Instance.ResetAmmo();
            // 버그 수정 현재 진행중인 스테이지 번호로 재시도
            fader.FadeTo(PlayerStats.Instance.CurrentScene);
        }

        public void Menu()
        {
            fader.FadeTo(loadToScene);
        }
    }
}
