using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;
using SO;

public class DataReadManager : MonoBehaviour
{
    const string URL = "https://docs.google.com/spreadsheets/d/1Sph3_eEfKFAfOT_EEN2-XzM9RK7mrly_9FTFSueqgSo/export?format=tsv";
    const string URLTurret = "https://docs.google.com/spreadsheets/d/1mUDMYbdVgwLQDmMQb2mB6kYl4SzZdbGfOmiaQ9Ww0g4/export?format=tsv";
    Dictionary<string, List<string>> setData = new Dictionary<string, List<string>>();
    Dictionary<string, List<string>> turretData = new Dictionary<string, List<string>>();
    public List<TankSO> tankSO;
    public List<TurretSO> turretSO;
    public string set;
    public string ret;


    public IEnumerator DataReader()
    {
        var getTankSO = Resources.LoadAll<TankSO>("ScriptableObject/Tanks");
        var getTurretSO = Resources.LoadAll<TurretSO>("ScriptableObject/Tanks");

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

        if (tankSO.Count == 0 && turretSO.Count == 0)
        {
            for (int i = 0; i < getTankSO.Length; i++)
            {
                tankSO.Add(getTankSO[i]);
            }

            for (int i = 0; i < getTurretSO.Length; i++)
            {
                turretSO.Add(getTurretSO[i]);
            }

        }

        for (int i = 1; i < row.Length; i++)
        {
            newData = row[i].Split('\t');
            for (int j = 0; j < newData.Length; j++)
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


        for (int i = 1; i < turretrow.Length; i++)
        {
            turretset = turretrow[i].Split('\t');
            for (int j = 0; j < turretset.Length; j++)
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


        foreach (var kvp in setData)
        {
            set = kvp.Key;
        }

        for (int i = 0; i < tankSO.Count; i++)
        {
            for (int j = 0; j < setData["이름"].Count; j++)
            {
                if (tankSO[i].name == setData["이름"][j] + "SO" || tankSO[i].name == setData["이름"][j] || tankSO[i].name == setData["이름"][j] + " SO")
                {
                    tankSO[i].acceleration = float.Parse(setData["가속"][j]);
                    Debug.Log(tankSO[i].acceleration);
                    tankSO[i].maxSpeed = float.Parse(setData["최고 속도"][j].Replace("km/h", ""));
                    Debug.Log(tankSO[i].maxSpeed);
                    tankSO[i].mass = float.Parse(setData["질량"][j].Replace("t", ""));
                    Debug.Log(tankSO[i].mass);
                    tankSO[i].hp = float.Parse(setData[set][j]);
                    Debug.Log(tankSO[i].hp);
                    tankSO[i].rotationSpeed = float.Parse(setData["선회속도(회전 속도)"][j].Replace("deg/s", ""));
                    Debug.Log(tankSO[i].rotationSpeed);
                    tankSO[i].armour = float.Parse(setData["장갑"][j]);
                    Debug.Log(tankSO[i].armour);
                }
            }
        }

        for (int i = 0; i < turretSO.Count; i++)
        {
            for (int j = 0; j < turretData["이름"].Count; j++)
            {
                if (turretSO[i].name == turretData["이름"][j] + "TurretSO" || turretSO[i].name == turretData["이름"][j] + " Turret" || turretSO[i].name == turretData["이름"][j] + "Turret")
                {
                    turretSO[i].reloadSpeed = float.Parse(turretData["장전시간"][j]);
                    Debug.Log(turretSO[i].reloadSpeed);
                    turretSO[i].rotationSpeed = float.Parse(turretData["포탑회전 속도"][j].Replace("deg/s", ""));
                    Debug.Log(turretSO[i].rotationSpeed);
                    turretSO[i].shellSpeed = float.Parse(turretData["포구 속도"][j].Replace("m/s", ""));
                    Debug.Log(turretSO[i].shellSpeed);
                }
            }
        }

    }
}
