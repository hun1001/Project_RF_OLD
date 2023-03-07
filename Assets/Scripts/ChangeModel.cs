using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModel : MonoBehaviour
{
    void Awake()
    {
        EventManager.StartListening("ChangeModel", (e) =>
        {
            var obj = e[0] as GameObject;

            Destroy(transform.GetChild(0).gameObject);
            Util.PoolManager.Instance.Get(obj, transform);

            FindObjectOfType<UI.MenuSceneCanvases>().ChangeCanvas("MenuCanvas");
        });
    }
}
