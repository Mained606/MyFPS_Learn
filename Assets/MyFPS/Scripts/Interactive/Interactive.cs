using UnityEngine;
using TMPro;

namespace MyFPS
{
    //인터렉티브 액션을 구현하는 클래스
    public abstract class Interactive : MonoBehaviour
    {
        protected abstract void DoAction();

        // 공통 변수
        protected float theDistance;
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Action Text";
        public GameObject extraCross;

        // 공통 메서드

        void Update()
        {
            theDistance = PlayerCasting.distanceFormTarget;
        }

        void OnMouseOver()
        {
            //거리가 2이하 일 때
            if (theDistance <= 2f)
            {
                ShowActionUi(action);

                if (Input.GetButtonDown("Action"))
                {
                    HideActionUI();

                    //액션
                    DoAction();

                }

            }
            else
            {
                HideActionUI();
            }
        }

        private void OnMouseExit()
        {
            HideActionUI();
        }

        protected void ShowActionUi(string action)
        {
            actionUI.SetActive(true);
            actionText.text = action;
            extraCross.SetActive(true);
        }

        protected void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
            extraCross.SetActive(false);
        }
    }
}