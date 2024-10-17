using UnityEngine;

namespace MyFPS
{
    public class GameOver : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        [SerializeField] private string loadToScene = "PlayScene";
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
            fader.FadeTo(loadToScene);
        }

        public void Menu()
        {
            Debug.Log("Goto Menu");
        }
    }

}
