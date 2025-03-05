using UnityEngine;

namespace Game.Scripts.Cores.CoreComponents
{
    public class CoreComponent : MonoBehaviour
    {
        protected Cores.Core Core;

        protected virtual void Awake()
        {
            Core = transform.parent.GetComponent<Cores.Core>();
        }
    }
}
