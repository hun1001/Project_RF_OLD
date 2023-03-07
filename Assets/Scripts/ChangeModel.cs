using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModel : MonoBehaviour
{
    private GameObject _model = null;

    void Awake()
    {
        _model = transform.GetChild(0).gameObject;

        EventManager.StartListening("ChangeModel", (e) =>
        {
            var obj = e[0] as GameObject;

            Destroy(_model);

            _model = Util.PoolManager.Instance.Get(obj, transform);

            FindObjectOfType<UI.MenuSceneCanvases>().ChangeCanvas("MenuCanvas");
        });
    }
}
