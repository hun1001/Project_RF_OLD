using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using SO;

public class DataReadManager : MonoBehaviour
{
    const string URL = "https://docs.google.com/spreadsheets/d/1Sph3_eEfKFAfOT_EEN2-XzM9RK7mrly_9FTFSueqgSo/export?format=tsv";
    const string URLTurret = "https://docs.google.com/spreadsheets/d/1mUDMYbdVgwLQDmMQb2mB6kYl4SzZdbGfOmiaQ9Ww0g4/export?format=tsv";
    Dictionary<string, List<string>> setData = new Dictionary<string, List<string>>();
    Dictionary<string, List<string>> turretData = new Dictionary<string, List<string>>();
    string soPath = "Assets/ScriptableObject/Tanks/";
    public List<TankSO> tankSO;
    public List<TurretSO> turretSO;
    public string set;
    public string ret;


    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        UnityWebRequest www2 = UnityWebRequest.Get(URLTurret);
        yield return www.SendWebRequest();
        yield return www2.SendWebRequest();

        string data = www.downloadHandler.text;
        string turret = www2.downloadHandler.text;

        string[] row = data.Split('\n');
        string[] turretrow = turret.Split('\n');
        string[] rowcol = row[0].Split('\t');
        string[] turretcol = turretrow[0].Split('\t');
        string[] newData = new string[9999];
        string[] turretset = new string[9999];

        for(int i = 0; i<row.Length; i++)
        {
            newData = row[i].Split('\t');
            for(int j = 0; j<newData.Length; j++)
            {
                if (setData.ContainsKey(rowcol[j]))
                {
                    setData[rowcol[j]].Add(newData[j]);
                }
                else
                {
                    setData[rowcol[j]] = new List<string>() { newData[j] };
                }
              
            }   
        }

        foreach(var kvp in setData)
        {
            Debug.Log(kvp.Key);
            set = kvp.Key;
        }
        

        for(int i = 0; i<turretrow.Length; i++)
        {
            turretset = turretrow[i].Split('\t');
            for(int j = 0; j< turretset.Length; j++)
            {
                if (turretData.ContainsKey(turretcol[j]))
                {
                    turretData[turretcol[j]].Add(turretset[j]);
                }
                else
                {
                    turretData[turretcol[j]] = new List<string>() { turretset[j] };
                }
            }
        }

        for(int i = 0; i<tankSO.Count; i++)
        {
            for(int j = 0; j<setData["�̸�"].Count; j++)
            {
                if (tankSO[i].name == setData["�̸�"][j]+"SO"||tankSO[i].name == setData["�̸�"][j]||tankSO[i].name == setData["�̸�"][j]+" SO")
                {
                    tankSO[i].acceleration = float.Parse(setData["����"][j]);
                    tankSO[i].maxSpeed = float.Parse(setData["�ְ� �ӵ�"][j].Replace("km/h",""));
                    tankSO[i].mass = float.Parse(setData["����"][j].Replace("t",""));
                    tankSO[i].hp = float.Parse(setData[set][j]);
                    tankSO[i].rotationSpeed = float.Parse(setData["��ȸ�ӵ�(ȸ�� �ӵ�)"][j].Replace("deg/s", ""));
                    tankSO[i].armour = float.Parse(setData["�尩"][j]);
                }
            }
        }

        for(int i = 0; i<turretSO.Count; i++)
        {
            for(int j =0; j<turretData.Count; j++)
            {
                if(turretSO[i].name == turretData["�̸�"][j]+"TurretSO"||turretSO[i].name == turretData["�̸�"][j]+" Turret"||turretSO[i].name == turretData["�̸�"][j]+"Turret")
                {
                    turretSO[i].reloadSpeed = float.Parse(turretData["�����ð�"][j]);
                    turretSO[i].rotationSpeed = float.Parse(turretData["��žȸ�� �ӵ�"][j].Replace("deg/s", ""));
                    turretSO[i].shellSpeed = float.Parse(turretData["���� �ӵ�"][j].Replace("m/s", ""));
                }
            }
        }
        
    }
}
