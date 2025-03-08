using UnityEngine;

namespace Game._Scripts.Generic
{
    public static class GenericNotImplementedError<T>
    {
        public static T TryGet(T value, string name)
        {
            if (value is not null)
            {
                return value;
            }
            
            Debug.LogError(typeof(T) + " not implemented on " + name);
            return default;
        }
    }
}
