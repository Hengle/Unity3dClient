using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using UnityEditor;

namespace GameClient
{
    public class XmlReader
    {
        public static void Read(PathNormalList pathList, string path = "Xml/path")
        {
            XmlDocument xmlDoc = new XmlDocument();
            TextAsset textAsset = AssetLoader.Instance().LoadRes(path,typeof(TextAsset)).obj as TextAsset;
            if (null == textAsset)
            {
                return;
            }
            //xmlDoc.LoadXml(Application.dataPath + @"\createRole.xml");  
            xmlDoc.LoadXml(textAsset.text);
            XmlNode root = xmlDoc.SelectSingleNode("FishPath");
            if(null == root)
            {
                return;
            }
            XmlNodeList children = root.ChildNodes;

            List<PathNormal> _tmpPathes = new List<PathNormal>(16);

            foreach (XmlNode node in children)
            {
                if(node.Name.Equals("Path"))
                {
                    int type = -1;
                    foreach (XmlAttribute element in node.Attributes)
                    {
                        if(element.Name.Equals("type"))
                        {
                            int.TryParse(element.Value, out type);
                            break;
                        }
                    }

                    if(type < 0 || type > 2)
                    {
                        continue;
                    }

                    int count = type + 2;
                    int pos = 0;
                    PathNormal pathNode = new PathNormal();
                    pathNode.positions = new Vector2[count];

                    foreach (XmlNode posNode in node.ChildNodes)
                    {
                        if(posNode.Name.Equals("Position"))
                        {
                            float x = 0.0f;
                            float y = 0.0f;
                            int flag = 0;
                            foreach (XmlAttribute element in posNode.Attributes)
                            {
                                if (element.Name == "x")
                                {
                                    if(float.TryParse(element.Value, out x))
                                    {
                                        flag |= 0x01;
                                    }
                                }
                                if (element.Name == "y")
                                {
                                    if(float.TryParse(element.Value, out y))
                                    {
                                        flag |= 0x02;
                                    }
                                }
                            }

                            if(flag == 0x03)
                            {
                                if (pos < pathNode.positions.Length)
                                    pathNode.positions[pos++] = new Vector2(x, y);
                                else
                                    pos++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    if(pos == count)
                    {
                        //Debug.LogFormat("<color=#00ff00>[type={0}]------------[count={1}]</color>",type, pathNode.positions.Length);
                        //for (int i = 0; i < pathNode.positions.Length; ++i)
                        //{
                        //    Debug.LogFormat("<color=#00ff00>[{0},{1}]</color>", pathNode.positions[i].x, pathNode.positions[i].y);
                        //}
                        _tmpPathes.Add(pathNode);
                    }
                    else
                    {
                        Debug.LogErrorFormat("create path failed !!!");
                        return;
                    }
                }
            }

            var fileName = Path.GetFileNameWithoutExtension(path);
            var assetPath = "Assets/Resources/" + path + ".asset";

            try
            {
                if (File.Exists(assetPath))
                {
                    PathNormalList oldAsset = AssetDatabase.LoadAssetAtPath<PathNormalList>(assetPath);
                    oldAsset.pathes = _tmpPathes.ToArray();
                    EditorUtility.SetDirty(oldAsset);
                    AssetDatabase.SaveAssets();
                }
                else
                {
                    var assetData = ScriptableObject.CreateInstance<PathNormalList>();
                    assetData.pathes = _tmpPathes.ToArray();
                    AssetDatabase.CreateAsset(assetData, assetPath);
                }
                Debug.LogFormat("<color=#00ff00>create asset {0} succeed !!!</color>", assetPath);
            }
            catch(System.Exception e)
            {
                Debug.LogErrorFormat(e.ToString());
            }
        }

        public static void BeginScene()
        {

        }
        public static void BuildFishScene6ToAsset(string path = "Scene/Fish/fish_scene_6")
        {
            var fileName = Path.GetFileNameWithoutExtension(path);
            var assetPath = "Assets/Resources/" + path + ".asset";

            try
            {
                if (File.Exists(assetPath))
                {
                    FishActionAsset oldAsset = AssetDatabase.LoadAssetAtPath<FishActionAsset>(assetPath);
                    //oldAsset.pathes = _tmpPathes.ToArray();
                    //EditorUtility.SetDirty(oldAsset);
                    //AssetDatabase.SaveAssets();
                }
                else
                {
                    //var assetData = ScriptableObject.CreateInstance<PathNormalList>();
                    //assetData.pathes = _tmpPathes.ToArray();
                    //AssetDatabase.CreateAsset(assetData, assetPath);
                }
                Debug.LogFormat("<color=#00ff00>create asset {0} succeed !!!</color>", assetPath);
            }
            catch (System.Exception e)
            {
                Debug.LogErrorFormat(e.ToString());
            }
        }
        public static void EndScene()
        {

        }
    }
}