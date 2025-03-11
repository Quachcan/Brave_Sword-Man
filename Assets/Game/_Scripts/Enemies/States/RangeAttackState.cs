using Game._Scripts.Enemies.EnemySpecific.Enemy3;
using Game._Scripts.Enemies.State_Machine;
using Game._Scripts.Enemies.States.Configs;
using Game._Scripts.ProjectTiles;
using UnityEngine;

namespace Game._Scripts.Enemies.States
{
    public class RangeAttackState : AttackState
    {

        protected RangedAttackStateConfig StateConfig;
        
        protected GameObject Projectile;
        protected Projectile ProjectileScript;
        private float lastAttackTime;

        protected bool IsAttackOver;
        public RangeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, RangedAttackStateConfig stateConfig) : base(entity, stateMachine, animBoolName, attackPosition)
        {
            this.StateConfig = stateConfig;
        }

        public override void Enter()
        {
            base.Enter();
            
            //IsAttackOver = false;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            // if (Time.time < lastAttackTime + StateConfig.attackCoolDown)
            // {
            //     IsAttackOver = true;
            // }
        }

        public override void TriggerAttack()
        {
            base.TriggerAttack();
            
            
            Projectile = Object.Instantiate(StateConfig.projectilePrefab, AttackPosition.position, AttackPosition.rotation); 
            ProjectileScript = Projectile.GetComponent<Projectile>();
            ProjectileScript.FireProjectile(StateConfig.projectileSpeed, StateConfig.projectileTravelDistance, StateConfig.projectileDamage);
        }
    }
}
