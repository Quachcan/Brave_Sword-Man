using System;
using Game.Scripts.Cores.CoreComponents;
using UnityEngine;

namespace Game.Scripts.Cores
{
    public class Core : MonoBehaviour
    {
        public Movement Movement
        {
            get
            {
                if (movement)
                {
                    return movement;
                }
                Debug.LogError("No movement found");
                return null;
            }
            private set => movement = value;
        }
        public CollisionSenses CollisionSenses
        { get
            {
                if (collisionSenses)
                {
                    return collisionSenses;
                }
                Debug.LogError("No collisionSenses found");
                return null;
            }
            private set => collisionSenses = value; 
        }
        
        private Movement movement;
        private CollisionSenses collisionSenses;

        private void Awake()
        {
            Movement = GetComponentInChildren<Movement>();
            CollisionSenses = GetComponentInChildren<CollisionSenses>();

            if (Movement == null || !CollisionSenses)
            {
                Debug.LogError("Core doesn't have Movement component");
            }
        }

        public void LogicUpdate()
        {
            Movement.LogicUpdate();
        }
    }
}
