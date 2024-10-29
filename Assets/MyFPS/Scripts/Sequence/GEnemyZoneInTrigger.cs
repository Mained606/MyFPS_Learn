using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class GEnemyZoneInTrigger : MonoBehaviour
    {
        #region Variables
        public Transform theGunMan;
        #endregion
        private void OnTriggerEnter(Collider other)
        {
            //건맨 추격 시작
            if(other.tag == "Player")
            {
                theGunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase);
            }
        }
    }
}
