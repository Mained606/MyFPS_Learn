using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class MoveWall : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float moveSpeed = 1f;

        [SerializeField] private float moveTime = 1f;
        private float countdown = 0f;

        [SerializeField] private float dir = 1f;
        #endregion

        void Start()
        {
            countdown = moveTime;
        }

        void Update()
        {
            if (countdown <= 0f)
            {
                dir *= -1f;

                countdown = moveTime;

            }
            countdown -= Time.deltaTime;

            transform.Translate(Vector3.right * dir * moveSpeed * Time.deltaTime, Space.World);
        }
    }

}
