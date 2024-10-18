using System.Collections;
using UnityEngine;
using TMPro;
using StarterAssets;

namespace MyFPS
{
    public class AOpening : MonoBehaviour
    {
        #region Variables
        [SerializeField] private GameObject thePlayer;
        public SceneFader fader;

        //시퀀스 UI
        [SerializeField] private TextMeshProUGUI textBox;
        [SerializeField] private string scenarioText1 = "...Where am I?";
        [SerializeField] private string scenarioText2 = "I need get out of here...";

        //시나리오 보이스
        public AudioSource voice1;
        public AudioSource voice2;

        #endregion
        void Start()
        {
            StartCoroutine(PlaySequence());
        }

        //오프닝 시퀀스
        IEnumerator PlaySequence()
        {
            // 1.플레이 캐릭터 비 활성화
            //thePlayer.SetActive(false);
            thePlayer.GetComponent<FirstPersonController>().enabled = false;

            // 2.페이드인 연출 (1초 대기후 페이드인 효과)
            fader.FromFade(4f); //2초동안 페이드인 효과 - (매개변수 1초 대기 후 페이드 1초)

            // 3.화면 하단에 시나리오 텍스트 화면 출력 (3초)
            // (...Where am I?)
            textBox.gameObject.SetActive(true);
            textBox.text = scenarioText1;
            voice1.Play();

            // (I need get Out of Here)
            yield return new WaitForSeconds(3f);
            textBox.text = scenarioText2;
            voice2.Play();

            // 4. 3초후에 시나리오 텍스트 사라짐
            yield return new WaitForSeconds(3f);
            textBox.text = "";
            textBox.gameObject.SetActive(false);

            // 5. 플레이어 캐릭터 활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = true;

        }
    }

}
