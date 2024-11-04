using UnityEngine;

namespace MyFPS
{
    public class HEnemyZoneOutTirgger : MonoBehaviour
    {
        #region Variables
        public Transform theGunMan;
        public GameObject enemyZoneIn; //인 트리거
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            //건맨 추격 종료
            if(other.tag == "Player")
            {
                if(theGunMan != null)
                {
                    theGunMan.GetComponent<Enemy>().GoStartPosition(); // 건맨 추격 종료 위치 재설정
                }
            }

            // ===============================================
            // 다른 방법 시도 후 삭제한 코드
            // if(other.tag == "Player" && 
            // theGunMan.GetComponent<Enemy>().CurrentState != EnemyState.E_Death)
            // {
            //     //건맨 추격 종료 위치 재설정
            //     theGunMan.GetComponent<Enemy>().GoStartPosition();
            // }
            // ===============================================
        }
        private void OnTriggerExit(Collider other)
        {
            if(other.tag == "Player")
            {
                this.gameObject.SetActive(false);
                enemyZoneIn.SetActive(true); // 인 트리거 활성화
            }
        }
    }
}
