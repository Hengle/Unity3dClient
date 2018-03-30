using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XUPorterJSON;
using GameClient;

public class AssetShaderLoader : Singleton<AssetShaderLoader>
{
    protected string m_ShaderListFile = "Shader/ShaderList.json";

    protected struct ShaderResDesc
    {
        public ShaderResDesc(string res,Shader shader)
        {
            m_ShaderRes = res;
            m_Shader = shader;
        }

        public string m_ShaderRes;
        public Shader m_Shader;
    }

    protected Dictionary<string, ShaderResDesc> m_ShaderNameMap = new Dictionary<string, ShaderResDesc>();

    public void Init()
    {
        TextAsset textAsset = AssetLoader.Instance().LoadRes(m_ShaderListFile,typeof(TextAsset)).obj as TextAsset;
        if (null != textAsset)
        {
            Hashtable shaderList = new Hashtable();
            try
            {
                shaderList = MiniJSON.jsonDecode(textAsset.text) as Hashtable;

                IDictionaryEnumerator it = shaderList.GetEnumerator();
                while(it.MoveNext())
                {
                    string shaderName = it.Key as string;
                    string shaderRes = it.Value as string;

                    if (!m_ShaderNameMap.ContainsKey(shaderName))
                        m_ShaderNameMap.Add(shaderName, new ShaderResDesc(shaderRes, null));
                }
            }
            catch (System.Exception e)
            {
                LogManager.Instance().LogErrorFormat( "Get shader list form json has failed! Exception:" + e.ToString());
            }
        }
        else
            LogManager.Instance().LogErrorFormat( "Load shader list has failed!");
    }

    public void UnInit()
    {
        m_ShaderNameMap.Clear();
    }

    public static Shader Find(string shaderName)
    {
        ShaderResDesc shaderDesc;
        if (Instance().m_ShaderNameMap.TryGetValue(shaderName, out shaderDesc))
        {
            if(null == shaderDesc.m_Shader)
            {
                Shader shader = AssetLoader.Instance().LoadRes(shaderDesc.m_ShaderRes, typeof(Shader)).obj as Shader;
                if (null != shader)
                    shaderDesc.m_Shader = shader;
            }
            return shaderDesc.m_Shader;
        }

        return Shader.Find(shaderName);
    }
}
