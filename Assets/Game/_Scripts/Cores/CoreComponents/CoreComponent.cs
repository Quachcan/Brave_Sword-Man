using Game._Scripts.Cores;
using Game.Scripts.Interfaces;
using UnityEngine;

namespace Game._Scripts.Cores.CoreComponents
{
    public class CoreComponent : MonoBehaviour, ILogicUpdate
    {
        protected Core Core;

        protected virtual void Awake()
        {
            Core = transform.parent.GetComponent<Core>();
            Core.AddComponent(this);
        }

        public virtual void LogicUpdate()
        {
            
        }
    }
}
