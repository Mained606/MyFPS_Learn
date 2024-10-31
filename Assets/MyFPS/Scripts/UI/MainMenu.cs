using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace MyFPS
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene01";

        private AudioManager audioManager;
        public GameObject mainMenuUI;
        public GameObject optionUI;
        public GameObject creditUI;

        //Audio
        public AudioMixer audioMixer;
        public Slider bgmSlider;
        public Slider sfxSlider;

        #endregion
        private void Start()
        {
            //게임 저장데이터, 저장된 옵션값 불러오기
            LoadOptions();

            //씬 페이드 인 효과
            fader.FromFade(0.5f);
            //참조
            audioManager = AudioManager.Instance;
            //BGM 플레이
            // audioManager.PlayBgm("MainBgm");
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
            audioManager.Stop(audioManager.BgmSound);
            audioManager.Play("MenuButton");
        }

        public void Options()
        {
            ShowOptions();
        }

        private void ShowOptions()
        {
            audioManager.Stop(audioManager.BgmSound);
            audioManager.Play("MenuButton");
            mainMenuUI.SetActive(false);
            optionUI.SetActive(true);
        }

        public void HideOptions()
        {
            audioManager.Stop(audioManager.BgmSound);
            audioManager.Play("MenuButton");

            //Save
            SaveOptions();

            mainMenuUI.SetActive(true);
            optionUI.SetActive(false);
        }

        public void SetBgmVolume(float value)
        {
            audioMixer.SetFloat("BgmVolume", value);
            
        }
        public void SetSfxVolume(float value)
        {
            audioMixer.SetFloat("SfxVolume", value);
            
        }
        private void SaveOptions()
        {
            PlayerPrefs.SetFloat("BgmVolume", bgmSlider.value);
            PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);

        }

        private void LoadOptions()
        {
            //배경음 볼륨
            float bgmVolume = PlayerPrefs.GetFloat("BgmVolume", 0);
            SetBgmVolume(bgmVolume); //사운드 볼륨 조절
            bgmSlider.value = bgmVolume; // UI 세팅

            //효과음 볼륨

            float sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 0);
            SetSfxVolume(sfxVolume); //사운드 볼륨 조절
            sfxSlider.value = sfxVolume; // UI 세팅
        }

        public void Credits()
        {
            ShowCredit();
        }

        private void ShowCredit()
        {
            mainMenuUI.SetActive(false);
            creditUI.SetActive(true);
        }


        public void QuitGame()
        {
            Debug.Log("게임 종료");
            Application.Quit();
        }
    }
    
}
