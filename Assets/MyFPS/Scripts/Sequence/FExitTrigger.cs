using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class FExitTrigger : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToSecne = "MainMenu";
        #endregion
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                PlaySequence();
            }
        }

        void PlaySequence()
        {
            fader.FadeTo(loadToSecne);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
