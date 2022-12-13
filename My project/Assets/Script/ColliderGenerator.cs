using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColliderGenerator : MonoBehaviour
{
    //SkinedMeshRenderer가 존재하는 경우
    private void Awake()
    {
        //SkinedMeshRenderer가 포함된 게임오브젝트 검색
        SkinnedMeshRenderer smr = FindChildComponent(transform);
        // smr.bounds 정보를 사용할 수도 있음
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.center = smr.bounds.center - transform.position;
        collider.size = smr.bounds.size;
        string localPath = Application.dataPath+"Assets/Resources/Saved"+gameObject.name+".prefab";
        PrefabUtility.SaveAsPrefabAsset(gameObject, localPath);
    }

    public SkinnedMeshRenderer FindChildComponent(Transform _tr)
    {
        SkinnedMeshRenderer smr = _tr.GetComponent<SkinnedMeshRenderer>();
        if (smr != null)
            return smr;

        for (int i=0; i<_tr.childCount; i++)
        {
            Transform tr = _tr.GetChild(i);
            FindChildComponent(tr);
        }
        return null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
