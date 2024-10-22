using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFPS
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene01";

        private AudioManager audioManager;
        #endregion
        private void Start()
        {
            //씬 페이드 인 효과
            fader.FromFade(0.5f);
            //참조
            audioManager = AudioManager.Instance;
            //BGM 플레이
            audioManager.PlayBgm("MainBgm");
        }

        public void NewGame()
        {
            audioManager.Stop(audioManager.BgmSound);
            audioManager.Play("MenuButton");
            fader.FadeTo(loadToScene);

        }

        public void LoadGame()
        {
            Debug.Log("로드 게임 시작");
        }

        public void Options()
        {
            audioManager.PlayBgm("MenuBgm2");
            Debug.Log("옵션 화면");
        }

        public void Credits()
        {
            Debug.Log("크레딧 화면");
        }

        public void QuitGame()
        {
            Debug.Log("게임 종료");
            Application.Quit();
        }
    }
    
}
