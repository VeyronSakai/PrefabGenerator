using UnityEngine;

namespace PrefabGenerator
{
    public static class PrefabDestroyer
    {
        public static void Destroy<T>(ref T prefab) where T : PrefabBase
        {
            if (prefab == null)
                return;

            Object.Destroy(prefab.gameObject);
            prefab = null;
        }
    }
}