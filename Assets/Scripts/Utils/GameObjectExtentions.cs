using UnityEngine;


namespace Utils
{
    public static class GameObjectExtentions
    {
        public static T AddCode<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetOrAddComponent<T>();
            return component;
        }

        private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result) result = gameObject.AddComponent<T>();

            return result;
        }
    }
}