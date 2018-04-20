using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameClient
{
    [System.Serializable]
    public class FishActionMoveBezier
    {
        public int _fish_id;
        public FishKind _kind;
        public List<MovePoint> _points = new List<MovePoint>();
    }
    [System.Serializable]
    public class FishActionMoveLiner
    {
        public int _fish_id;
        public FishKind _kind;
        public float _speed;
        public Vector2 _start;
        public Vector2 _end;
    }

    [System.Serializable]
    public class FishActionAsset : ScriptableObject
    {
        public FishActionMoveBezier[] pathes = new FishActionMoveBezier[0];
        public FishActionMoveLiner[] line_pathes = new FishActionMoveLiner[0];
    }
}