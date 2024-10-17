using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFPS
{
    public class PlayerController : MonoBehaviour, IDamageable
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "GameOverScene";
        private float maxHealth = 20f;
        public float currentHealth;
        public bool isDead = false;

        //데미지 효과
        public GameObject damageFlash;
        public AudioSource hurt01;
        public AudioSource hurt02;
        public AudioSource hurt03;
        #endregion
        void Awake()
        {
            currentHealth = maxHealth;
        }


        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log("currentHealth: " + currentHealth);

            //데미지 효과
            StartCoroutine(DamegeEffect());
            //체력이 0이하이고 죽지 않았다면 죽는다.
            if(currentHealth <= 0 && !isDead)
            {
                Die();
            }
        }
        
        void Die()
        {
            isDead = true;
            fader.FadeTo(loadToScene);
            Debug.Log("Player is Dead");
        }

        IEnumerator DamegeEffect()
        {
            //데미지 효과
            damageFlash.SetActive(true);
            
            int randNumber = Random.Range(1, 4);
            if(randNumber == 1)
            {
                hurt01.Play();
            }
            else if(randNumber == 2)
            {
                hurt02.Play();
            }
            else
            {
                hurt03.Play();
            }
            yield return new WaitForSeconds(1f);
            damageFlash.SetActive(false);
        }
    }
}
