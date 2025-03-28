using System;
using Game._Scripts.Cores.CoreComponents;
using Game._Scripts.Interfaces;
using UnityEngine;

namespace Game._Scripts.Enemies.Traps
{
    public class SpikeTrap : MonoBehaviour
    {
        [SerializeField] private float damage = 999999f;
        [SerializeField] private LayerMask whatIsPlayer;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (((1 << other.gameObject.layer) & whatIsPlayer.value) != 0)
            {
                IDamageable damageable = other.GetComponent<IDamageable>();
                damageable?.Damage(damage);
            }
        }
    }
}
