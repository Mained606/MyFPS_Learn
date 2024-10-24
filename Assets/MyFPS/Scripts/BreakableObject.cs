using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class BreakableObject : MonoBehaviour, IDamageable
    {
        #region Variables
        public GameObject brokenObject;
        public GameObject fakeObject;
        public GameObject effectObject;
        public GameObject hiddenItem;
        private bool isBroken = false;
        [SerializeField] private bool unbreakable = false;
        [SerializeField]private bool haveHiddenItem = false;
        #endregion
        public void TakeDamage(float amount)
        {
            if(unbreakable) return;

            if(!isBroken)
            {
                StartCoroutine(BreakObject());
            }
        }

        IEnumerator BreakObject()
        {
            isBroken = true;
            this.GetComponent<Collider>().enabled = false;
            // brokenObject.GetComponentInParent<Collider>().enabled = false;
            AudioManager.Instance.Play("PotterySmash");

            fakeObject.SetActive(false);
            // yield return new WaitForSeconds(0.1f);
            brokenObject.SetActive(true);

            if(effectObject != null )
            {
                effectObject.SetActive(true);
                yield return new WaitForSeconds(0.05f);
                effectObject.SetActive(false);
            }

            if(haveHiddenItem)
            {
                hiddenItem.SetActive(true);
                // DontDestroyOnLoad(hiddenItem);
            }

            // Destroy(this.gameObject, 3f);

            yield return null;
        }
    }
    
}
