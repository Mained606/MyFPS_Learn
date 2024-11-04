using UnityEngine;

namespace MyFPS
{
    public class PickupPistol : Interactive
    {
        #region Variables

        //action
        public GameObject realPistol;
        public GameObject arrow;
        public GameObject enemyTrigger;
        public GameObject ammoUi;
        public GameObject ammoBox;

        // ===============================================
        // 다른 방법 시도 후 삭제한 코드
        // private float theDistance;

        //action Ui
        // public GameObject actionUI;
        // public TextMeshProUGUI actionText;
        // public GameObject extraCross;
        // [SerializeField] private string action = "Puckup Pistol";
        // ===============================================
        #endregion


        protected override void DoAction()
        {
            arrow.SetActive(false);
            ammoBox.SetActive(true);
            //플레이어 무기 획득 셋팅
            PlayerStats.Instance.SetHasWeapon(true);
            
            //AmmoUi 활성화
            ammoUi.SetActive(true);

            //실제 무기 활성화
            realPistol.SetActive(true);

            //크로스 헤어 체인지
            crossHair.SetActive(false);
            pistolCross.SetActive(true);

            //EnemyTrigger 활성화
            enemyTrigger.SetActive(true);


            Destroy(this.gameObject);
        }

        // ===============================================
        // 다른 방법 시도 후 삭제한 코드
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
        // ===============================================

        // ===============================================
        // 다른 방법 시도 후 삭제한 코드
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
        // ===============================================
    }

}