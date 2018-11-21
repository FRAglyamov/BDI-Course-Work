using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEditor;

public class SmartObjectActionAssetScript : Editor
{

    [MenuItem("Tools/Generate Smart Object Action Scripts")]
    static void ReGenerateSmartObjectActionAsset()

    {
        string path = Application.dataPath + "/Scripts/SmartObjectAction/";

        string[] actionsFull = Directory.GetFiles(path);


        foreach (string str in actionsFull)
        {
            string filename = str.Substring(str.LastIndexOf("/") + 1);

            var createdAction = Directory.GetFiles(Application.dataPath + "/SmartObjectAction/");
            bool isCreated = false;

            if (filename.EndsWith(".cs") && !isCreated)
            {
                string fileName = filename.Remove(filename.Length - 3);

                foreach (var act in createdAction)
                {
                    if (act.EndsWith(".asset"))
                    {
                        //Debug.Log("Act: " + act);
                        var tmp = act.Split('/');
                        var actFile = tmp[tmp.Length - 1];
                        if (actFile.Remove(actFile.Length - 6) == fileName)
                        {
                            isCreated = true;
                            break;
                        }
                    }
                }
                //Debug.Log("fileName: " + fileName + ": " + isCreated);

                if(!isCreated)
                {
                    var actionName = fileName;
                    var action = ScriptableObject.CreateInstance(actionName);
                    AssetDatabase.CreateAsset(action, "Assets/SmartObjectAction/" + actionName + ".asset");
                    AssetDatabase.SaveAssets();
                }
            }

        }



    }
}
