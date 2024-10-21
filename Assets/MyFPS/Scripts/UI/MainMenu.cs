using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFPS
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene01";
        #endregion
        private void Start()
        {
            fader.FromFade(0.5f);
        }

        public void NewGame()
        {
            fader.FadeTo(loadToScene);
        }

        public void LoadGame()
        {
            Debug.Log("로드 게임 시작");
        }

        public void Options()
        {
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
