using Unity.VisualScripting;
using UnityEngine;

namespace MyFPS
{
    public class AudioManager : PersistentSingleton<AudioManager>
    {
        #region Variables
        public Sound[] sounds;
        private string bgmSound = ""; // 현재 플레이 되는 배경음 이름
        public string BgmSound
        {
            get { return bgmSound; }
        }

        #endregion

        protected override void Awake()
        {
            //싱글톤 구현부
            base.Awake();

            //AudioManager 초기화
            foreach (var sound in sounds)
            {
                sound.source = this.gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;
                sound.source.loop = sound.loop;
                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
                
            }
        }

        public void Play(string name)
        {
            Sound sound = null;
            //매개변수 이름과 같은 클립 찾기
            foreach (var s in sounds)
            {
                if(s.name == name)
                {
                    sound = s;
                    break;
                }
            }
            if(sound == null)
            {
                Debug.Log($"Connot Find {name}");
                return;
            }
            // sound.source?.Play();
            sound.source.Play();
        }

        public void Stop(string name)
        {
            Sound sound = null;
            //매개변수 이름과 같은 클립 찾기
            foreach (var s in sounds)
            {
                if(s.name == name)
                {
                    sound = s;

                    //
                    if(s.name == bgmSound)
                    {
                        bgmSound = "";
                    }
                    break;
                }
            }
            //매개변수 이름과 같은 클립이 없으면
            if(sound == null)
            {
                Debug.Log($"Connot Find {name}");
                return;
            }
            // sound.source?.Play();
            sound.source.Stop();
        }

        //배경음 재생
        public void PlayBgm(string name)
        {
            //배경음 이름 체크
            if(bgmSound == name)
            {
                return;
            }
            //배경음 정지
            Stop(bgmSound);

            Sound sound = null;

            foreach (var s in sounds)
            {
                if(s.name == name)
                {
                    bgmSound = s.name;
                    sound = s;
                    break;
                }
            }

            if(sound == null)
            {
                Debug.Log($"Connot Find {name}");
                return;
            }
            // sound.source?.Play();
            sound.source.Play();
        }
    }

}
