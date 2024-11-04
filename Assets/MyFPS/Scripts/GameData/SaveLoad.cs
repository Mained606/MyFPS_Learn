using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyFPS
{
    //게임 데이터 파일 저장/ 가져오기 구현 - 이진화 저장
    public static class SaveLoad
    {
        public static string fileName = "/playData.arr";

        // 게임 데이터를 파일에 저장하는 메서드
        public static void SaveData()
        {
            //파일 이름, 경로 지정
            string path = Application.persistentDataPath + fileName;

            //이진화 포맷터 생성
            BinaryFormatter formatter = new BinaryFormatter();
            
            //파일 접근 - 존재하면 파일 가져오기, 존재하지 않으면 파일 새로 생성
            FileStream file = new FileStream(path, FileMode.Create);

            //파일에 저장할 데이터 세팅
            PlayData playData = new PlayData();
            Debug.Log(playData.ToString());

            //파일에 데이터 저장
            formatter.Serialize(file, playData);

            //파일 닫기
            file.Close();
        }

        public static PlayData LoadData()
        {
            PlayData playData;

            //파일 이름, 경로 지정
            string path = Application.persistentDataPath + fileName;

            //파일 존재 여부 확인
            if(File.Exists(path))
            {
                //이진화 포맷터 생성
                BinaryFormatter formatter = new BinaryFormatter();

                //파일 접근
                FileStream file = new FileStream(path, FileMode.Open);

                //파일에서 데이터 역직렬화
                playData = formatter.Deserialize(file) as PlayData;
                Debug.Log(playData.currentScene);

                //파일 닫기
                file.Close();
            }
            else
            {
                Debug.Log("No save data");
                playData = null;
            }
            // 불러온 데이터 반환
            return playData;
        }

        public static void DeleteFile()
        {
            string path = Application.persistentDataPath + fileName;
            File.Delete(path);
        }
    }

}
