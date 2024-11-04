using System.Collections;
using UnityEngine;

namespace MyFPS
{
    public class CEnemyTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject theDoor; //문
        public GameObject theRobot; //로봇
        public AudioSource doorBang; //문 열리는 소리
        public AudioSource bgm01;
        public AudioSource bgm02; //점프 스크어 소리
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
            //콜라이더 비활성화 중복 방지
            // this.GetComponent<BoxCollider>().enabled = false;

            //문 열기
            theDoor.GetComponent<Animator>().SetBool("IsOpen", true);
            theDoor.GetComponent<BoxCollider>().enabled = false;

            //문 사운드
            bgm01.Stop();
            doorBang.Play();

            //Enemy 활성화
            theRobot.SetActive(true);
            yield return new WaitForSeconds(1f);

            //Enemy 등장 사운드
            bgm02.Play();

            //Enemy 걷기
            RobotController robot = theRobot.GetComponent<RobotController>();
            if(robot != null)
            {
                robot.SetState(RobotState.R_Walk);
            }   

            //트리거 킬
            Destroy(this.gameObject);

            yield return null;
        }
    }
}