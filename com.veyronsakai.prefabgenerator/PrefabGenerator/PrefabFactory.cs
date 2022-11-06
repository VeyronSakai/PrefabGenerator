using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PrefabGenerator
{
    public static class PrefabFactory
    {
        public static T Create<T>(string prefabPath) where T : MonoBehaviour
        {
            var obj = LoadPrefab(prefabPath);

            var gameObject = InstantiateGameObject(obj);

            var instance = gameObject.GetComponent<T>();

            if (instance == null)
            {
                throw new ArgumentException($"Script {typeof(T)} is not attached to {prefabPath}");
            }

            return instance;
        }

        public static T Create<T>(string prefabPath, Transform parent) where T : MonoBehaviour
        {
            var obj = LoadPrefab(prefabPath);

            var gameObject = InstantiateGameObject(obj, parent);

            var instance = gameObject.GetComponent<T>();

            if (instance == null)
            {
                throw new ArgumentException($"Script {typeof(T)} is not attached to {prefabPath}");
            }

            return instance;
        }

        public static T Create<T>(string prefabPath, Transform parent, Vector3 position) where T : MonoBehaviour
        {
            var obj = LoadPrefab(prefabPath);

            var gameObject = UnityEngine.Object.Instantiate(obj, position, Quaternion.identity, parent) as GameObject;

            if (gameObject == null)
            {
                throw new InvalidCastException();
            }

            var instance = gameObject.GetComponent<T>();

            if (instance == null)
            {
                throw new ArgumentException($"Script {typeof(T)} is not attached to {prefabPath}");
            }

            return instance;
        }

        public static void Create(string prefabPath, Transform parent)
        {
            var obj = LoadPrefab(prefabPath);

            InstantiateGameObject(obj, parent);
        }

        private static Object LoadPrefab(string prefabPath)
        {
            var obj = Resources.Load(prefabPath);

            if (obj == null)
            {
                throw new ArgumentException($"Prefab does not exist in the path {prefabPath}");
            }

            return obj;
        }

        private static GameObject InstantiateGameObject(Object obj, Transform parent = null)
        {
            GameObject gameObject;

            if (parent == null)
            {
                gameObject = Object.Instantiate(obj) as GameObject;
            }
            else
            {
                gameObject = Object.Instantiate(obj, parent) as GameObject;
            }

            if (gameObject == null)
            {
                throw new InvalidCastException();
            }

            return gameObject;
        }
    }
}