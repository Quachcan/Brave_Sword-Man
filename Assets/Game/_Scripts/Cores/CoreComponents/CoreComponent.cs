using Game.Scripts.Interfaces;
using UnityEngine;

namespace Game.Scripts.Cores.CoreComponents
{
    public class CoreComponent : MonoBehaviour, ILogicUpdate
    {
        protected Cores.Core Core;

        protected virtual void Awake()
        {
            Core = transform.parent.GetComponent<Cores.Core>();
            Core.AddComponent(this);
        }

        public virtual void LogicUpdate()
        {
            
        }
    }
}
