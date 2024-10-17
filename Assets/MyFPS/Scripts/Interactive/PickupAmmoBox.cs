using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyFPS
{
    public class PickupAmmoBox : Interactive
    {
        #region Variables
        //아이템 획득 시 지급하는 Ammo 갯수
        [SerializeField] private int giveAmmoCount = 7;
        #endregion

        protected override void DoAction()
        {
            PlayerStats.Instance.AddAmmo(giveAmmoCount);
            //킬
            Destroy(this.gameObject);
        }

    }

}
