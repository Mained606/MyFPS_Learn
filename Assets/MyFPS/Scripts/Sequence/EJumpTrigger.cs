using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

namespace MyFPS
{
    public class EJumpTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject thePlayer;
        public GameObject activateObject;
        #endregion

        public void OnTriggerEnter(Collider other)
        {
            
            // this.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(PlaySequence());
        }


        IEnumerator PlaySequence()
        {
            //플레이어 캐릭터 비활성화(이동 멈춤)
            thePlayer.GetComponent<FirstPersonController>().enabled = false;
            activateObject.SetActive(true);
            yield return new WaitForSeconds(2f);

            //연출용 액션 오브젝트 킬
            // activateObject.SetActive(false);
            Destroy(activateObject, 2f);


            thePlayer.GetComponent<FirstPersonController>().enabled = true;

            //트리거 킬
            Destroy(this.gameObject);


        }
    }
    
}
