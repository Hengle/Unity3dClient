using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ETCImageLoader {

    public static bool LoadSprite(ref Image image, string path, bool isMustExist = true)
    {
        image.material = null;
        AssetInst inst = AssetLoader.Instance().LoadRes(path, typeof(Sprite), isMustExist);
        if(null == inst || null == inst.obj)
        {
            return false;
        }

        image.sprite = inst.obj as Sprite;
        string texturePath = GetTexturePathFromSprite(path);
        string fileExt = Path.GetExtension(texturePath);
        string materialPath = "";
        if (null == fileExt || fileExt.Length <= 0)
        {
            materialPath = texturePath + "_Material.mat";
        }
        else
        {
            materialPath = texturePath.Replace(fileExt, "_Material.mat");
        }

        AssetInst materialInst = AssetLoader.Instance().LoadRes(materialPath, typeof(Material), false);
        if(null == materialInst || null == materialInst.obj)
        {
            image.canvasRenderer.SetAlphaTexture(null);
            return true;
        }

        image.material = materialInst.obj as Material;
        image.canvasRenderer.SetAlphaTexture(image.material.GetTexture("_AlphaTex"));


        //if (File.Exists(materialPath))
        //{
        //    image.material = AssetLoader.Instance().LoadRes(materialPath, typeof(Material), isMustExist).obj as Material;
        //}

        return true;
    }

    public static bool HasSprite(string path)
    {
        AssetInst inst = AssetLoader.Instance().LoadRes(path, typeof(Sprite), false);
        if(null == inst || null == inst.obj)
        {
            return false;
        }

        return true;
    }

    public static Texture LoadAlphaFromSpritePath(string path, bool isMustExist = true)
    {
        string texturePath = GetBasePathFromSpritePath(path) + "_Alpha.png";

        AssetInst inst = AssetLoader.Instance().LoadRes(texturePath, typeof(Texture), isMustExist);
        if(null == inst || null == inst.obj)
        {
            return null;
        }

        return inst.obj as Texture;
    }

    public static Material LoadMaterialFromSpritePath(string path, bool isMustExist = true)
    {
        string material = GetBasePathFromSpritePath(path) + "_Material.mat";

        AssetInst inst = AssetLoader.Instance().LoadRes(material, typeof(Material), isMustExist);
        if (null == inst || null == inst.obj)
        {
            return null;
        }

        return inst.obj as Material;
    }

    public static string GetTexturePathFromSprite(string path)
    {
        int index = path.IndexOf(":");
        if(index < 0)
        {
            return path;
        }

        return path.Substring(0, index);
    }

    public static string GetBasePathFromSpritePath(string path)
    {
        string texturePath = GetTexturePathFromSprite(path);
        int index = texturePath.LastIndexOf(".");
        if(index < 0)
        {
            return texturePath;
        }

        return texturePath.Substring(0, index);
    }
}
