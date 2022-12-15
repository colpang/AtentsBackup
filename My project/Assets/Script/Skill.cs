using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    private Do doSkill;
    public Do DOSkILL
    {
        get { return doSkill; }
        set { doSkill = value; }
    }
    public void OnSkill()
    {
        if (doSkill != null)
            doSkill();
    }
}
