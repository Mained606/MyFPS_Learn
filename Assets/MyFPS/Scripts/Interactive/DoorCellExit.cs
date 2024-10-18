using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class DoorCellExit : Interactive
    {
        #region Variables
        public SceneFader fader;
        private string loadToSecne = "MainScene02";

        private Animator animator;
        private Collider m_Collider;
        public AudioSource creakyDoor;

        public AudioSource bgm01;

        #endregion

        void Start()
        {
            animator = GetComponent<Animator>();
            m_Collider = GetComponent<Collider>();
        }


        protected override void DoAction()
        {
            // 1. 문 여는 애니메이션
            animator.SetBool("IsOpen", true);
            // 2. 콜라이더 비활성화
            m_Collider.enabled = false;
            // 3. 문 여는 사운드
            creakyDoor.Play();

            ChangeScene();
        }

        void ChangeScene()
        {

            //씬 마무리,...
            bgm01.Stop();

            //다음 씬으로 이동...
            fader.FadeTo(loadToSecne);
        }


    }

}
