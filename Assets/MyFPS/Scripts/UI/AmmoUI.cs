using UnityEngine;

namespace MyFPS
{
    public class AmmoUI : MonoBehaviour
    {
        #region Variables
        public GameObject ammoUi;
        #endregion

        void Start()
        {
            ShowAmmoUI();
        }

        private void ShowAmmoUI()
        {
            ammoUi.SetActive(PlayerStats.Instance.HasWeapon); // 무기 소지 여부에 따라 UI 활성화
        }
    }
}
