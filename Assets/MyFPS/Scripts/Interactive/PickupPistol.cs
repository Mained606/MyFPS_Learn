using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFPS
{
    public class PickupPistol : Interactive
    {
        #region Variables
        // private float theDistance;

        //action Ui
        // public GameObject actionUI;
        // public TextMeshProUGUI actionText;
        // public GameObject extraCross;
        // [SerializeField] private string action = "Puckup Pistol";

        //action
        public GameObject realPistol;
        public GameObject arrow;
        #endregion

        // void Update()
        // {
        //     theDistance = PlayerCasting.distanceFormTarget;
        // }

        // void OnMouseOver()
        // {
        //     //거리가 2이하 일 때
        //     if (theDistance <= 2f)
        //     {
        //         ShowActionUi();

        //         if (Input.GetButtonDown("Action"))
        //         {
        //             HideActionUI();

        //             //액션
        //             DoAction();

        //         }

        //     }
        //     else
        //     {
        //         HideActionUI();
        //     }
        // }
        // private void OnMouseExit()
        // {
        //     HideActionUI();
        // }

        protected override void DoAction()
        {
            realPistol.SetActive(true);
            arrow.SetActive(false);
            Destroy(this.gameObject);
        }

        // private void ShowActionUi()
        // {
        //     actionUI.SetActive(true);
        //     actionText.text = action;
        //     extraCross.SetActive(true);
        // }

        // private void HideActionUI()
        // {
        //     actionUI.SetActive(false);
        //     actionText.text = "";
        //     extraCross.SetActive(false);
        // }
    }

}