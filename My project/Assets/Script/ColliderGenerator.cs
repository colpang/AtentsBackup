using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColliderGenerator : MonoBehaviour
{
    //SkinedMeshRenderer�� �����ϴ� ���
    private void Awake()
    {
        //SkinedMeshRenderer�� ���Ե� ���ӿ�����Ʈ �˻�
        SkinnedMeshRenderer smr = FindChildComponent(transform);
        // smr.bounds ������ ����� ���� ����
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
