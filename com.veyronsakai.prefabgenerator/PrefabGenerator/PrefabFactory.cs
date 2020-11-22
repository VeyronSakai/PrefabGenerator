using System;
using UnityEngine;

namespace PrefabGenerator
{
    public class PrefabFactory
    {
        public T Create<T>(string prefabPath) where T : PrefabBase
        {
            // TODO: Resourcesフォルダが無い場合は例外を出す
            
            var obj = Resources.Load(prefabPath);

            if (obj == null)
            {
                throw new ArgumentException($"指定したパス{prefabPath}にPrefabが存在しません。");
            }

            var gameObject = UnityEngine.Object.Instantiate(obj) as GameObject;

            if (gameObject == null)
            {
                throw new InvalidCastException();
            }

            var instance = gameObject.GetComponent<T>();

            if (instance == null)
            {
                throw new ArgumentException($"{typeof(T)}スクリプトが{prefabPath}にアタッチされていません。");
            }

            return instance;
        }
    }
}