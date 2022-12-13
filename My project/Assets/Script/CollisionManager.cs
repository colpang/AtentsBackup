using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    List<BoxCollider> colliderList;
    BoxCollider player;
    // Start is called before the first frame update
    void Awake()
    {
        colliderList = new List<BoxCollider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>();
        GameObject[] mobs = GameObject.FindGameObjectsWithTag("Monster");
        for (int i = 0; i < mobs.Length; i++)
            colliderList.Add(mobs[i].GetComponent<BoxCollider>());
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < colliderList.Count; i++)
        {
            if (player.bounds.Intersects(colliderList[i].bounds))
                player.gameObject.SendMessage("OnCollisionStayinBounds", colliderList[i]);
        }
    }
}
