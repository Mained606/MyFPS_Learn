using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace MyFPS
{
    public class Intro : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene01";

        //0.15
        public CinemachineDollyCart cart;

        private bool[] isArrive;
        [SerializeField] private int wayPointIndex = 0;

        public Animator cameraAnim;
        public GameObject introUI;
        public GameObject theShedLight;
        #endregion

        void Start()
        {
            //초기화
            cart.m_Speed = 0f;
            isArrive = new bool[7];

            StartCoroutine(StartIntro());

        }

        void Update()
        {
            //도착판정
            if(cart.m_Position >= wayPointIndex && isArrive[wayPointIndex] == false)
            {
                //연출
                if(wayPointIndex == isArrive.Length - 1)
                {
                    //마지막 지점
                    StartCoroutine(EndIntro());
                }
                else
                {
                    StartCoroutine(StayIntro());
                }
            }

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                GoToMainScene();
            }
        }

        IEnumerator StartIntro()
        {
            isArrive[wayPointIndex] = true;
            wayPointIndex++;

            fader.FromFade();
            AudioManager.Instance.PlayBgm("IntroBgm");
            yield return new WaitForSeconds(1f);

            //카메라 애니메이션
            cameraAnim.SetTrigger("ArroundTrigger");
            yield return new WaitForSeconds(3f);

            cart.m_Speed = 0.15f;
        }

        IEnumerator StayIntro()
        {
            isArrive[wayPointIndex] = true;
            wayPointIndex++;
            cart.m_Speed = 0f;

            Debug.Log($"{wayPointIndex - 1}");
            yield return new WaitForSeconds(1f);

            //카메라 애니메이션
            cameraAnim.SetTrigger("ArroundTrigger");

            int nowIndex = wayPointIndex - 1; //현재 위치하고 있는 웨이포인트인덱스

            switch(nowIndex)
            {
                case 1:
                    introUI.SetActive(true);
                    break;
                case 2:
                    introUI.SetActive(false);
                    break;
                case 5:
                    break;
            }

            yield return new WaitForSeconds(3f);

            if(nowIndex == 5)
            {
                theShedLight.SetActive(true);
                yield return new WaitForSeconds(1f);
            }

            //출발
            cart.m_Speed = 0.15f;
        }

        IEnumerator EndIntro()
        {
            isArrive[wayPointIndex] = true;
            cart.m_Speed = 0f;

            yield return new WaitForSeconds(2f);
            theShedLight.SetActive(false);
            yield return new WaitForSeconds(2f);


            AudioManager.Instance.StopBgm();
            fader.FadeTo(loadToScene);

        }

        private void GoToMainScene()
        {
            AudioManager.Instance.StopBgm();
            fader.FadeTo(loadToScene);
        }
    }

}
