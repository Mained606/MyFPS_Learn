using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class SoundTest : MonoBehaviour
    {
        #region Variables
        private AudioSource audioSource;
        public AudioClip clip; //재생할 오디오 클립
        [SerializeField] private float volume = 1.0f;
        [SerializeField] private float pitch = 1.0f;
        [SerializeField] private bool looping = false;
        [SerializeField] private bool playOnAwake = false;
        
        #endregion

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }    
        
        void SoundPlay()
        {
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.loop = looping;

            audioSource.Play();
        }

        void SoundOnShot()
        {
            audioSource.PlayOneShot(clip);
        }
    }

}
