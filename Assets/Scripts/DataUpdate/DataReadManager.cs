using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using SO;

public class DataReadManager : MonoBehaviour
{
    const string URL = "https://docs.google.com/spreadsheets/d/1wXlWQ0fiFp1mDJiqnh9V2Qe4pGtroN_HKhJP4GgiXaA/export?format=tsv";
    const string URLTurret = "";
    Dictionary<string, List<string>> setData = new Dictionary<string, List<string>>();
    Dictionary<string, List<string>> turretData = new Dictionary<string, List<string>>();
    string soPath = "Assets/ScriptableObject/Tanks/";
    public List<TankSO> tankSO;
    public List<TurretSO> turretSO;


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
                
                Debug.Log(setData[rowcol[j]][i]);
            }   
        }

        for(int i = 0; i<turretrow.Length; i++)
        {
            turretset = turret.Split('\t');
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
            for(int j = 0; j<setData["이름"].Count; j++)
            {
                if (tankSO[i].name == setData["이름"][j])
                {
                    tankSO[i].acceleration = float.Parse(setData["가속"][j]);
                    tankSO[i].maxSpeed = float.Parse(setData["최고속도"][j]);
                    tankSO[i].mass = float.Parse(setData["질량"][j]);
                    tankSO[i].hp = float.Parse(setData["체력"][j]);
                    tankSO[i].rotationSpeed = float.Parse(setData["선회속도(회전 속도)"][j]);
                    tankSO[i].armour = float.Parse(setData["장갑"][j]);
                }
            }
        }

        for(int i = 0; i<turretSO.Count; i++)
        {
            for(int j =0; j<turretData.Count; j++)
            {
                if(turretSO[i].name == turretData["이름"][j]+" Turret")
                {
                    turretSO[i].reloadSpeed = float.Parse(turretData["장전시간"][j]);
                    turretSO[i].rotationSpeed = float.Parse(turretData["포탑회전 속도"][j].Replace("deg/s", ""));
                    turretSO[i].shellSpeed = float.Parse(turretData["포구 속도"][j].Replace("m/s", ""));
                }
            }
        }
        
    }
}
