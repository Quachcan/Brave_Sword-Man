using System;
using System.Collections.Generic;
using Game.Scripts.Cores.CoreComponents;
using UnityEngine;
using System.Linq;

namespace Game.Scripts.Cores
{
    public class Core : MonoBehaviour
    {
        
        private readonly List<CoreComponent> coreComponents = new  List<CoreComponent>();

        public void LogicUpdate()
        {
            foreach (var component in coreComponents)
            {
                component.LogicUpdate();
            }
        }

        public void AddComponent(CoreComponent component)
        {
            if (!coreComponents.Contains(component))
            {
                coreComponents.Add(component);
            }
        }

        public T GetCoreComponent<T>() where T : CoreComponent
        {
            var comp =  coreComponents.OfType<T>().FirstOrDefault();

            if (comp) 
                return comp;
            comp = GetComponentInChildren<T>();

            if (comp)
                return comp;
            Debug.LogWarning($"{typeof(T).Name} not found on {transform.parent.name}");

            return null;
        }

        public T GetCoreComponent<T>(ref T value) where T : CoreComponent
        {
            value = GetCoreComponent<T>();
            return value;
        }
    }
}
