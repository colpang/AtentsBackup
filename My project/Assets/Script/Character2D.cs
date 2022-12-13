using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2D : MonoBehaviour
{
    Rect rect;
    public Rect RC { get { return rect; } }
    public Character2D other;
    // Start is called before the first frame update
    void Start()
    {
        rect.x = transform.position.x;
        rect.y = transform.position.y;
        rect.width = 1f;
        rect.height = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        rect.x = transform.position.x;
        rect.y = transform.position.y;

        if (rect.Overlaps(other.RC))
        {
            Debug.Log(other.name + "°ú Ãæµ¹");
        }
    }
}
