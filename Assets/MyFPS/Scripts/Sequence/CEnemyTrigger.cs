using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{

    public class CEnemyTrigger : MonoBehaviour
    {
        #region Variables
        [SerializeField] private GameObject theDoor;


        #endregion

        private void Awake()
        {
        
        }

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
            theDoor.GetComponent<Animator>().SetBool("IsOpen", true);
            theDoor.GetComponent<BoxCollider>().enabled = false;

            yield return null;


        }
    }

}