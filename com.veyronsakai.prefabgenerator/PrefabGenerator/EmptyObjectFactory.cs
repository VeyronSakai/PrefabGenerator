using UnityEngine;

namespace PrefabGenerator
{
    public static class EmptyObjectFactory
    {
        public static GameObject Create(string objName)
        {
            var obj = new GameObject(objName);
            return obj;
        }

        public static GameObject Create(string objName, Transform parent)
        {
            var obj = new GameObject(objName);
            obj.transform.parent = parent;
            return obj;
        }
    }
}