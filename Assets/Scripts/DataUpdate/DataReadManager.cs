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
            //row ���̸�ŭ ���� ���� ������ dictionary���ٰ� ����
        }

        //�ش� ������ dictionory Ű �� ���� ������ ���� ���� List�� �ߺ���Ű�� ���� �ε��� ����

        //�ش� �����͸� �о�� ������ ���� �̸� SO�� ���� ��� �ش� �����͸� ���� ��Ŵ
    }
}
