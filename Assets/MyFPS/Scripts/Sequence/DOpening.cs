using System.Collections;
using UnityEngine;
using TMPro;
using StarterAssets;

namespace MyFPS
{
    public class DOpening : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        public GameObject thePlayer;
        public TextMeshProUGUI textBox;
        #endregion

        void Start ()
        {
            StartCoroutine(SequencePlay());
            // 커서 잠금
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        IEnumerator SequencePlay()
        {
            //플레이어 비활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = false;

            // 배경음 시작
            AudioManager.Instance.PlayBgm("PlayBgm");

            // 시퀀스 텍스트 초기화
            textBox.text = ""; 

            // 1초 후 페이드인 효과 시작
            yield return new WaitForSeconds(1f);
            fader.FromFade();

            thePlayer.GetComponent<FirstPersonController>().enabled = true;
        }
    }
}
