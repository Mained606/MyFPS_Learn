using System.Collections;
using UnityEngine;

namespace MyFPS
{
    public class Title : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";
        public GameObject anyKeyUI;
        private bool isAnyKey = false;
        #endregion

        void Start()
        {
            fader.FromFade();
            isAnyKey = false;
            StartCoroutine(TitleProcess());
        }

        void Update()
        {
            if (Input.anyKey && isAnyKey)
            {
                GotoMenu();
            }
        }

        IEnumerator TitleProcess()
        {
            yield return new WaitForSeconds(4f);
            isAnyKey = true;
            anyKeyUI.SetActive(true);

            yield return new WaitForSeconds(10f);
            GotoMenu() ;
        }

        private void GotoMenu()
        {
            StopAllCoroutines();
            fader.FadeTo(loadToScene);
        }
    }
}