using StarterAssets;
using System.Collections;
using TMPro;
using UnityEngine;

namespace MyFPS
{
    public class BFristTrigger: MonoBehaviour
    {
        #region Variable
        [SerializeField] private GameObject thePlayer;
        [SerializeField] private GameObject theArrow;

        //시퀀스 UI
        [SerializeField] private TextMeshProUGUI textBoxText;
        public string scenarioText = "Looks like a weapon on that table";
        [SerializeField] private AudioSource voice3;

        // private bool isTrigger = false;
        #endregion

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());

            // ===============================================
            // 다른 방법 시도 후 삭제한 코드
            // //한 번만 실행되도록 실행중인지 체크
            // if(!isTrigger)
            // {
            //     StartCoroutine(PlaySequence());
            // }
            // ===============================================
        }

        IEnumerator PlaySequence()
        {
            //실행중인지 체크
            // isTrigger = true;

            //플레이어 캐릭터 비활성화
            //thePlayer.gameObject.SetActive(false);
            thePlayer.GetComponent<FirstPersonController>().enabled = false;


            //대사 출력
            textBoxText.gameObject.SetActive(true);
            voice3.Play();
            textBoxText.text = scenarioText;

            //1초 딜레이
            yield return new WaitForSeconds(1f);

            //화살표 활성화
            theArrow.gameObject.SetActive(true);

            // 1초 딜레이
            yield return new WaitForSeconds(1f);

            //대사 초기화
            textBoxText.text = "";
            textBoxText.gameObject.SetActive(false);

            thePlayer.GetComponent<FirstPersonController>().enabled = true;

            //충돌 비활성화
            //gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject);

            //플레이 캐릭터 활성화(다시 플레이)
            //thePlayer.gameObject.SetActive(true);
        }
    }
}