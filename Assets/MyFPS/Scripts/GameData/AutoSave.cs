using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFPS
{
    // 플레이씬이 시작하면 자동으로 게임 데이터를 저장하는 클래스
    public class AutoSave : MonoBehaviour
    {
        private void Start()
        {
            //씬 번호 저장 실행
            AutoSaveData();
        }

        private void AutoSaveData()
        {
            // 현재 씬 번호를 가져옴
            int currentScene = PlayerStats.Instance.CurrentScene;
            int playScene = SceneManager.GetActiveScene().buildIndex;

            // 현재 씬 번호보다 큰 경우에만 저장
            if (playScene > currentScene)
            {
                PlayerStats.Instance.CurrentScene = playScene;
                SaveLoad.SaveData(); // 데이터 저장
            }
        }
    }
}
