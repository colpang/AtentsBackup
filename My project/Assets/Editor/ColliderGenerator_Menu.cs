using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColliderGenerator_Menu : MonoBehaviour
{
    [MenuItem("ColliderGenerator/CreateGenerator")]
    public static void CreateGenerator()
    {
        //이 방법은 씬에 오브젝트가 올려져 있어야 사용이 가능함.
        GameObject[] objs = Resources.LoadAll<GameObject>("Character");
        for(int i = 0; i < objs.Length; i++)
        {
            SkinnedMeshRenderer smr = objs[i].GetComponentInChildren<SkinnedMeshRenderer>();
            BoxCollider collider = objs[i].AddComponent<BoxCollider>();
            collider.center = smr.bounds.center - objs[i].transform.position;
            collider.size = smr.bounds.size;
            string localPath = Application.dataPath + "Assets/Resources/Saved" + objs[i].name + ".prefab";
            PrefabUtility.SaveAsPrefabAsset(objs[i], localPath);
        }
    }
}
