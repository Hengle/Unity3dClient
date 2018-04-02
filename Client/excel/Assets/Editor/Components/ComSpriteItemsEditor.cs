using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using GameClient;

[CustomEditor(typeof(ComSpriteItems))]
public class ComSpriteItemsEditor : Editor
{
    protected SerializedProperty components = null;

    public void OnEnable()
    {
        components = serializedObject.FindProperty("srcSprite");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUI.BeginChangeCheck();

        base.OnInspectorGUI();

        if(EditorGUI.EndChangeCheck())
        {
            ComSpriteItems current = (target as ComSpriteItems);
            if(null != current && null == current.sprite)
            {
                current.sprite = current.GetComponent<Image>();
            }

            if(null != current.sprite)
            {
                var texture = components.objectReferenceValue as Texture2D;
                if (null != texture)
                {
                    var path = AssetDatabase.GetAssetPath(texture);
                    var sprites = AssetDatabase.LoadAllAssetsAtPath(path);
                    if (null != sprites && sprites.Length > 1)
                    {
                        (target as ComSpriteItems)._pools = new Sprite[sprites.Length - 1];
                        var pools = (target as ComSpriteItems)._pools;
                        for (int i = 0; i < pools.Length; ++i)
                        {
                            pools[i] = sprites[i + 1] as Sprite;
                        }
                        current.sprite.sprite = sprites[1] as Sprite;
                        current.sprite.SetNativeSize();
                    }
                    else
                    {
                        (target as ComSpriteItems)._pools = new Sprite[0];
                    }
                }
                else
                {
                    (target as ComSpriteItems)._pools = new Sprite[0];
                }
            }
        }
    }
}
