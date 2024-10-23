using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

namespace MyFPS
{
    public class PauseUI : MonoBehaviour
    {
        #region Variables
        public GameObject pauseUi;
        private GameObject thePlayer;
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";
        #endregion

        void Start()
        {
            //참조
            thePlayer = GameObject.Find("Player");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) // && !isSequence
            {
                Toggle();
            }
        }

        public void Toggle()
        {
            pauseUi.SetActive(!pauseUi.activeSelf);

            if(pauseUi.activeSelf) // pause 창이 오픈 될 때, 사운드? && !isSequence
            {
                thePlayer.GetComponent<FirstPersonController>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
            else // pause 창이 클로즈 될 때
            {
                thePlayer.GetComponent<FirstPersonController>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;

            }
        }

        public void Menu()
        {
            Time.timeScale = 1;

            //씬 종료 처리
            // Debug.Log("메뉴로 이동");
            // AudioManager.Instance.StopBgm();
            fader.FadeTo(loadToScene);
        }

        public void Contiune()
        {
            Toggle();
        }

        // 게임 매니저에 스크립트를 넣는 경우의 코드 (P로 퍼즈)
        //// 활성화시 마우스 락 해제 및 게임 일시정지
        //private void OnEnable()
        //{

        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
        //    Time.timeScale = 0;

        //}

        //// 비활성화시 마우스 락 및 게임 일시정지 해제
        //private void OnDisable()
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = false;
        //    Time.timeScale = 1;
        //}


        //public void Continue()
        //{
        //    this.gameObject.SetActive(false);
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = false;
        //    Time.timeScale = 1;
        //}

        //public void Menu()
        //{
        //    Debug.Log("메인 메뉴로 이동");
        //}
    }

}
