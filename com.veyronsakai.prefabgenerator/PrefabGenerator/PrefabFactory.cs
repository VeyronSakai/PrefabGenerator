using System;
using UnityEngine;

namespace PrefabGenerator
{
    public static class PrefabFactory
    {
        public static T Create<T>(string prefabPath) where T : PrefabBase
        {
            var obj = Resources.Load(prefabPath);

            if (obj == null)
            {
                throw new ArgumentException($"Prefab does not exist in the path {prefabPath}");
            }

            var gameObject = UnityEngine.Object.Instantiate(obj) as GameObject;

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

        public static T Create<T>(string prefabPath, Transform parent) where T : PrefabBase
        {
            var obj = Resources.Load(prefabPath);

            if (obj == null)
            {
                throw new ArgumentException($"Prefab does not exist in the path {prefabPath}");
            }

            var gameObject = UnityEngine.Object.Instantiate(obj, parent) as GameObject;

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
    }
}