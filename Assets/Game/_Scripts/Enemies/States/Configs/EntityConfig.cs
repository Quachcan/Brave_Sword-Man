﻿using UnityEngine;

namespace Game.Scripts.Enemies.States.Data
{
    [CreateAssetMenu(fileName = "newEntityConfig", menuName = "Config/Entity Config/Base Config")]
    public class EntityConfig : ScriptableObject
    {
        public float maxHealth = 30f;

        public float damageHopSpeed = 3f;

        public float wallCheckDistance = 0.2f;
        public float ledgeCheckDistance = 0.4f;
        public float groundCheckRadius = 0.3f;

        public float minAgroDistance = 3f;
        public float maxAgroDistance = 4f;

        public float stunResistance = 3f;
        public float stunRecoveryTime = 2f;

        public float closeRangeActionDistance = 1f;

        public GameObject hitParticle;

        public LayerMask whatIsGround;
        public LayerMask whatIsPlayer;
    }
}
