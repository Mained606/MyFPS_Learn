using UnityEngine;

namespace MyFPS
{
    public class FlyingObject : MonoBehaviour
    {
        #region Variables
        private float velocity = 2f;
        #endregion
        void OnCollisionEnter(Collision collision)
        {
            if (collision.relativeVelocity.magnitude > velocity)
                AudioManager.Instance.Play("CupFall");
        }
    }
}
