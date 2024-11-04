using UnityEngine;

namespace MyFPS
{
    // 파일에 저장할 게임 플레이 데이터 목록을 정의하는 클래스
    [System.Serializable]
    public class PlayData
    {
        public int currentScene; // 현재 씬 번호
        public int ammoCount;    // 남은 탄약 수
        public bool hasWeapon;   // 무기 소지 여부

        // 생성자: PlayerStats의 현재 상태를 기반으로 초기화
        public PlayData()
        {
            this.currentScene = PlayerStats.Instance.CurrentScene;
            this.ammoCount = PlayerStats.Instance.AmmoCount;
            this.hasWeapon = PlayerStats.Instance.HasWeapon;
        }
    }
}
