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

        public GameObject enemyTrigger;

        public GameObject ammoUi;
        public GameObject ammoBox;

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
            crossHair.SetActive(false);
            pistolCross.SetActive(true);
            arrow.SetActive(false);

            //AmmoUi 활성화
            ammoUi.SetActive(true);
            ammoBox.SetActive(true);

            //EnemyTrigger 활성화
            enemyTrigger.SetActive(true);

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