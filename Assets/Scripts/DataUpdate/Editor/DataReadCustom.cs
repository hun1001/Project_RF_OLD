//using UnityEditor;
//using UnityEngine;

//[CustomEditor(typeof(DataReadManager))]
//public class DataReadCustom : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        DrawDefaultInspector();

//        DataReadManager reader = (DataReadManager)target;
//        if (GUILayout.Button("Data Read")) reader.StartCoroutine(reader.DataReader());
//    }
//}
