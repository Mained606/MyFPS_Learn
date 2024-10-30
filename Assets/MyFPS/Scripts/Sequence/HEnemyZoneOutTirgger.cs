using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyFPS
{
    public class HEnemyZoneOutTirgger : MonoBehaviour
    {
        public Transform theGunMan;
        public GameObject enemyZoneIn; //인 트리거

        private void OnTriggerEnter(Collider other)
        {
            //건맨 추격 종료
            if(other.tag == "Player")
            {
                if(theGunMan != null)
                {
                    theGunMan.GetComponent<Enemy>().GoStartPosition();
                }
            }
            
            // if(other.tag == "Player" && 
            // theGunMan.GetComponent<Enemy>().CurrentState != EnemyState.E_Death)
            // {
            //     //건맨 추격 종료 위치 재설정
            //     theGunMan.GetComponent<Enemy>().GoStartPosition();
            // }
        }
        private void OnTriggerExit(Collider other)
        {
            if(other.tag == "Player")
            {
                this.gameObject.SetActive(false);
                enemyZoneIn.SetActive(true);
            }
        }
    }

}
