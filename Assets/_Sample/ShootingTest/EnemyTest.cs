using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyFPS;

namespace MySample
{
    public class EnemyTest : MonoBehaviour, IDamageable
    {
        #region Variables
        [SerializeField] private float maxHealth = 100f;
        private float currentHealth;
        private bool isDead = false;
        #endregion

        void Start()
        {
            currentHealth = maxHealth;
            isDead = false;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            Debug.Log("남은 에너지 : " + currentHealth);
            if (currentHealth <= 0 && !isDead)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("Enemy is dead");
            isDead = true;
            Destroy(gameObject);
        }
    }

}
