using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DataReadManager : MonoBehaviour
{
    const string URL = "";
    Dictionary<string, List<string>> setData = new Dictionary<string, List<string>>();

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;

        string[] row = data.Split('\n');
        string[] col = row[0].Split('\t');
        int rowsize = row.Length;

        for(int i = 1; i<col.Length; i++)
        {
            //row 길이만큼 제목 문장 나눠서 dictionary에다가 저장
        }

        //해당 데이터 dictionory 키 값 마다 폴더를 만든 다음 List로 중복된키에 벨류 인덱스 삽입

        //해당 데이터를 읽어와 동일한 파일 이름 SO가 있을 경우 해당 데이터를 적용 시킴
    }
}
