using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MyFPS
{
    public class SceneFader : MonoBehaviour
    {
        #region Variables
        //Fader 이미지
        public Image image;
        public AnimationCurve curve;
        #endregion

        private void Start()
        {
            // //씬 시작시 페이드인 효과
            // StartCoroutine(FadeIn());

            //초기화 : 시작시 화면을 검은색으로 시작
            image.color = new Color(0f, 0f, 0f, 1f);
        }

        //delayTime 만큼 대기후 페이드인 효과
        public void FromFade(float delayTime = 0f)
        {
            //씬 시작시 페이드인 효과
            StartCoroutine(FadeIn(delayTime));
        }

        IEnumerator FadeIn(float delayTime)
        {
            //0보다 클 때만 delayTime 만큼 대기
            if(delayTime > 0f)
            {
                yield return new WaitForSeconds(delayTime);
            }
            //1초동안 image a 1-> 0
            float t = 1f;

            while (t > 0)
            {
                t -= Time.unscaledDeltaTime;
                float a = curve.Evaluate(t);
                image.color = new Color(0f, 0f, 0f, a);
                yield return 0f;    
            }
        }

        public void FadeTo(string sceneName)
        {
            StartCoroutine(FadeOut(sceneName));
        }

        public void FadeTo(int sceneName)
        {
            StartCoroutine(FadeOut(sceneName));
        }

        IEnumerator FadeOut(string sceneName)
        {
            //1초동안 image a 0-> 1
            float t = 0f;

            while (t < 1f)
            {
                t += Time.unscaledDeltaTime;
                float a = curve.Evaluate(t);
                image.color = new Color(0f, 0f, 0f, a);
                yield return 0f;
            }
            //다음씬 로드
            SceneManager.LoadScene(sceneName);
        }

        IEnumerator FadeOut(int sceneName)
        {
            //1초동안 image a 0-> 1
            float t = 0f;

            while (t < 1f)
            {
                t += Time.unscaledDeltaTime;
                float a = curve.Evaluate(t);
                image.color = new Color(0f, 0f, 0f, a);
                yield return 0f;
            }

            //다음씬 로드
            SceneManager.LoadScene(sceneName);
        }
    }
}