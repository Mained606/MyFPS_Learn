using UnityEngine;

namespace MyFPS
{
    public class PickupAmmo : PickupItem
    {
        #region Variable
        [SerializeField] private int giveAmount = 7;
        #endregion

        protected override bool OnPickup()
        {
            //탄환 7개 획득
            PlayerStats.Instance.AddAmmo(giveAmount);
            return true;
        }
    }

}
