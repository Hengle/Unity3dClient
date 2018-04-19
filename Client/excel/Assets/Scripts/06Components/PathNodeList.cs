using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PathNormal
{
    public int type;
    public Vector2[] positions = new Vector2[0];
}

[System.Serializable]
public class PathNormalList : ScriptableObject
{
    public PathNormal[] pathes = new PathNormal[0];
}