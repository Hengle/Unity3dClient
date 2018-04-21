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
    public class FishActionMoveScene3
    {
        public int _fish_id;
        public FishKind _kind;
        public Vector2 center;
        public float radius;
        public float rotate_duration;
        public float start_angle;
        public float rotate_angle;
        public float move_duration;
        public float fish_speed;
    }

    [System.Serializable]
    public class FishActionAsset : ScriptableObject
    {
        public FishActionMoveBezier[] pathes = new FishActionMoveBezier[0];
        public FishActionMoveLiner[] line_pathes = new FishActionMoveLiner[0];
        public FishActionMoveScene3[] scene3_pathes = new FishActionMoveScene3[0];
    }
}