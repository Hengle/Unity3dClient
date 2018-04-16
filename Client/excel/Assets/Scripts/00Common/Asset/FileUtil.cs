using UnityEngine;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using XLua;
using GameClient;
using System.Text;
using System;

[LuaCallCSharp]
public class FileUtil
{
    public static string GetFileMD5(string filePath)
    {
        string md5str = "";
        if (-1 != FileExists(filePath))
        {
            FileStream fs = File.OpenRead(filePath);

            MD5 md5Hash = MD5.Create();

            byte[] md5Data = md5Hash.ComputeHash(fs);

            for (int i = 0; i < md5Data.Length; i++)
            {
                md5str += md5Data[i].ToString("x2");
            }

            fs.Close();
        }

        return md5str;
    }


    static byte[] buf = new byte[256*1024];
    static WaitForEndOfFrame WAIT_FOR_EOF = new WaitForEndOfFrame();
    static public string md5 = "";
    public static IEnumerator GetFileMD5Async(string file)
    {
        md5 = "";
        if (-1 != FileExists(file))
        {
            MD5 md5Hash = MD5.Create();
            md5Hash.Initialize();
            yield return WAIT_FOR_EOF;
            FileStream fs = File.OpenRead(file);
            yield return WAIT_FOR_EOF;

            long bytesRead = fs.Length;
            int byteRead = 0;
            byte[] output = new byte[buf.Length];
            while (fs.Position < fs.Length)
            {
                byteRead = fs.Read(buf, 0, buf.Length);
                md5Hash.TransformBlock(buf, 0, byteRead, output, 0);

                yield return WAIT_FOR_EOF;
            }

            md5Hash.TransformFinalBlock(buf, 0, 0);

            yield return WAIT_FOR_EOF;
            byte[] md5Data = md5Hash.Hash;
            for (int i = 0; i < md5Data.Length; i++)
            {
                md5 += md5Data[i].ToString("x2");
            }

            fs.Close();
        }
    }

    public static long GetFileBytes(string path)
    {
        long cbSize = 0;
        if (-1 != FileExists(path))
        {
            FileInfo fi = new FileInfo(path);
            cbSize = fi.Length;
        }

        return cbSize;
    }

    public static long FileExists(string path)
    {
        long lSize = -1;

        if (File.Exists(path))
        {
            FileStream fs = File.OpenRead(path);
            lSize = fs.Length;
            fs.Close();
        }

        return lSize;
    }

    [LuaCallCSharp]
    public static byte[] ReadFileFromResource(string fileName)
    {
        if(string.IsNullOrEmpty(fileName))
        {
            LogManager.Instance().LogErrorFormat("path is empty !");
            return new byte[0];
        }

        var assetInst = AssetLoader.Instance().LoadRes(fileName, typeof(AssetBinary));
        if (null != assetInst && null != assetInst.obj)
        {
            AssetBinary file = assetInst.obj as AssetBinary;
            if (file != null)
            {
                LogManager.Instance().LogProcessFormat(2001, "load file <color=#00ff00>{0}</color> succeed ! length={1}", fileName, file.m_DataBytes.Length);
                return file.m_DataBytes;
            }
        }

        LogManager.Instance().LogProcessFormat(2001, "load file <color=#ff0000>{0}</color> failed !", fileName);
        return new byte[0];
    }

    public static bool HasFile(string path)
	{
		return File.Exists(path);
	}
}
