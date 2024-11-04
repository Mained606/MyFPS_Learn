using UnityEngine;

namespace MyFPS
{
    public class GEnemyZoneInTrigger : MonoBehaviour
    {
        #region Variables
        public Transform theGunMan;
        public GameObject enemyZoneOut; //아웃 트리거
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            //건맨 추격 시작

            if(other.tag == "Player")
            {
                if(theGunMan != null)
                {
                    theGunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase);
                }
            }
            
            // ===============================================
            // 다른 방법 시도 후 삭제한 코드
            // if(other.tag == "Player" && 
            // theGunMan.GetComponent<Enemy>().CurrentState != EnemyState.E_Death)
            // {
            //     theGunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase);
            // }
            // ===============================================
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.tag == "Player")
            {
                this.gameObject.SetActive(false);
                enemyZoneOut.SetActive(true);
            }
        }
    }
}
