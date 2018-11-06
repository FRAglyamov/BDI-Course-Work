using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEditor;

public class SmartObjectActionAssetScript : Editor {

    [MenuItem("Tools/ReGenerate Smart Object Action Scripts")]
    static void ReGenerateSmartObjectActionAsset()
    {
        string path = Application.dataPath + "/Scripts/SmartObjectAction/";

        string[] actionsFull = Directory.GetFiles(path);


        int x = 0;
        foreach (string str in actionsFull)
        {
            string filename = str.Substring(str.LastIndexOf("/") + 1);

            if (filename.EndsWith(".cs"))
            {
                string fileName = filename.Remove(filename.Length - 3);

                var actionName = fileName;
                var action = ScriptableObject.CreateInstance(actionName);
                AssetDatabase.CreateAsset(action, "Assets/SmartObjectAction/" + actionName + ".asset");
                AssetDatabase.SaveAssets();

                Debug.Log(fileName);
                x++;
            }

        }



    }
}
