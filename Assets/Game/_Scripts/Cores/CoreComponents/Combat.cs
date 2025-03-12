using Game._Scripts.Interfaces;
using Game.Scripts.Interfaces;
using UnityEngine;

namespace Game._Scripts.Cores.CoreComponents
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
        
        private bool isKnockBackActive;
        private float knockBackStartTime;
        
        public override void LogicUpdate()
        {
            CheckKnockBack();
        }
        public void Damage(float damage)
        {
            Debug.Log(Core.transform.parent.name + $" Damaged: {damage}");
            Stats?.DecreaseHealth(damage);
            ParticleManager?.StartParticleWithRandomRotation(particlePrefab);
        }

        public void KnockBack(Vector2 angle, float strength, int direction)
        {
            Movement?.SetVelocity(strength, angle, direction);
            if (Movement != null)                   
                 Movement.CanSetVelocity = false;
            isKnockBackActive = true;
            //Debug.Log(Core.transform.parent.name + $" KnockBack Active: {isKnockBackActive}");
            knockBackStartTime = Time.time;
        }   

        private void CheckKnockBack()
        {
            //Debug.Log(isKnockBackActive);
            if (isKnockBackActive && Movement.CurrentVelocity.y <= 0.1f && CollisionSenses.Ground)
            {
                isKnockBackActive = false;
                Movement.CanSetVelocity = true;
            }
        }
    }   
}
