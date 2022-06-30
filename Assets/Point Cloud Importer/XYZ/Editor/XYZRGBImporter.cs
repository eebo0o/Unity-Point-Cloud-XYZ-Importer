using UnityEngine;
using UnityEngine.Rendering;
#if UNITY_2020_2_OR_NEWER
using UnityEditor.AssetImporters;
#else 
using UnityEditor.Experimental.AssetImporters;
#endif
using System;
using System.IO;
using System.Linq;

namespace Pcx
{
    [ScriptedImporter(1, "xyzrgb")]
    public class XYZRGBImporter : ScriptedImporter
    {
        public enum ContainerType
        {
            Mesh,
            ComputeBuffer
        }

        [SerializeField] ContainerType containerType = ContainerType.Mesh;

        public override void OnImportAsset(AssetImportContext context)
        {
            if (containerType == ContainerType.Mesh)
            {
                var gameObject = new GameObject();
                var mesh = ImportAsMesh(context.assetPath);

                var meshFilter = gameObject.AddComponent<MeshFilter>();
                meshFilter.sharedMesh = mesh;

                var meshRenderer = gameObject.AddComponent<MeshRenderer>();
                meshRenderer.sharedMaterial = PlyImporter.GetDefaultMaterial();

                context.AddObjectToAsset("prefab", gameObject);
                if (mesh != null) context.AddObjectToAsset("mesh", mesh);

                //context.SetMainObject(gameObject);
            }
            else if (containerType == ContainerType.ComputeBuffer)
            {
                var gameObject = new GameObject();
                var data = ImportAsPointCloudData(context.assetPath);

                var renderer = gameObject.AddComponent<PointCloudRenderer>();
                renderer.sourceData = data;

                context.AddObjectToAsset("prefab", gameObject);
                if (data != null) context.AddObjectToAsset("data", data);

                //context.SetMainObject(gameObject);
            }
        }

        private Mesh ImportAsMesh(string filePath)
        {
            try
            {
                var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader reader = new StreamReader(stream);
                DataBody body = ReadeBodyData(reader);


                var mesh = new Mesh();
                mesh.name = Path.GetFileNameWithoutExtension(filePath);

                mesh.indexFormat = body.vertices.Count > 65535 ? IndexFormat.UInt32 : IndexFormat.UInt16;

                mesh.SetVertices(body.vertices);
                mesh.SetColors(body.colors);

                mesh.SetIndices(
                    Enumerable.Range(0, body.vertices.Count).ToArray(),
                    MeshTopology.Points, 0
                );

                mesh.UploadMeshData(true);
                return mesh;
            }
            catch (Exception e)
            {
                Debug.LogError("Failed importing " + filePath + ". " + e.Message);
                return null;
            }
        }

        private PointCloudData ImportAsPointCloudData(string filePath)
        {
            try
            {
                var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader reader = new StreamReader(stream);
                var body = ReadeBodyData(reader);
                var data = ScriptableObject.CreateInstance<PointCloudData>();
                data.Initialize(body.vertices, body.colors);
                data.name = Path.GetFileNameWithoutExtension(filePath);
                return data;
            }
            catch (Exception e)
            {
                Debug.LogError("Failed importing " + filePath + ". " + e.Message);
                return null;
            }
        }

        private DataBody ReadeBodyData(StreamReader reader)
        {
            DataBody body = new DataBody();
            float x, y, z;
            byte r, g, b, a = 255;
            while (reader.Peek() >= 0)
            {
                string line = reader.ReadLine();
                string[] splitedLine = line.Split(' ');
                if (splitedLine.Length > 3)
                {
                    x = float.Parse(splitedLine[0]);
                    y = float.Parse(splitedLine[1]);
                    z = float.Parse(splitedLine[2]);
                    r = byte.Parse(splitedLine[3]);
                    g = byte.Parse(splitedLine[4]);
                    b = byte.Parse(splitedLine[5]);
                    
                }
                else
                {
                    x = float.Parse(splitedLine[0]);
                    y = float.Parse(splitedLine[1]);
                    z = float.Parse(splitedLine[2]);
                    r = g = b = a = 255;
                }
                body.AddPoint(x, y, z, r, g, b, a);
            }

            return body;
        }
        
    }
}