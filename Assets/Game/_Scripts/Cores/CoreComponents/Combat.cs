using Game._Scripts.Cores.CoreComponents;
using Game.Scripts.Interfaces;
using UnityEngine;

namespace Game.Scripts.Cores.CoreComponents
{
    public class Combat : CoreComponent, IDamageable, IKnockBackAble
    {
        private Movement Movement => movement ?? Core.GetCoreComponent(ref movement);
        private CollisionSenses CollisionSenses => collisionSenses ?? Core.GetCoreComponent(ref collisionSenses);
        private Stats Stats => stats ?? Core.GetCoreComponent(ref stats);
        private ParticleManager ParticleManager => particleManager ? particleManager : Core.GetCoreComponent(ref particleManager);
        
        private Movement movement;
        private CollisionSenses collisionSenses;
        private Stats stats;
        private ParticleManager particleManager;
        
        [SerializeField] private GameObject particlePrefab;
        [SerializeField] private float maxKnockBackTime = 0.2f;
        
        public override void LogicUpdate()
        {
            CheckKnockBack();
        }
        
        private bool isKnockBackActive;
        private float knockBackStartTime;
        public void Damage(float damage)
        {
            Debug.Log(Core.transform.parent.name + $" Damaged: {damage}");
            Stats?.DecreaseHealth(damage);
            ParticleManager?.StartParticleWithRandomRotation(particlePrefab);
        }

        public void KnockBack(Vector2 angle, float strength, int direction)
        {
            Movement?.SetVelocity(strength, angle, direction);
            if (Movement is not null) Movement.CanSetVelocity = false;
            isKnockBackActive = true;
            knockBackStartTime = Time.time;
        }

        private void CheckKnockBack()
        {
            if (isKnockBackActive && ((Movement?.CurrentVelocity.y <= 0.01f) && CollisionSenses.Ground) ||
                Time.time >= knockBackStartTime + maxKnockBackTime)
            {
                isKnockBackActive = false;
                if (Movement is not null) Movement.CanSetVelocity = true;
            }
        }
    }
}
