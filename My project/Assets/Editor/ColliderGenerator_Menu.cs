using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColliderGenerator_Menu : MonoBehaviour
{
    [MenuItem("ColliderGenerator/CreateGenerator")]
    public static void CreateGenerator()
    {
        //�� ����� ���� ������Ʈ�� �÷��� �־�� ����� ������.
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
