using UnityEngine;
using TMPro;

namespace MyFPS
{
    public class DrawAmmoUI : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI ammoCountText;
        #endregion

        // Update is called once per frame
        void Update()
        {
            ammoCountText.text = PlayerStats.Instance.AmmoCount.ToString();
        }
    }
}
