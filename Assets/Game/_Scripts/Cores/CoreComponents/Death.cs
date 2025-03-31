using Game._Scripts.Manager;
using UnityEngine;

namespace Game._Scripts.Cores.CoreComponents
{
    public class Death : CoreComponent
    {
        [SerializeField] private GameObject[] deathParticles;
        
        private ParticleManager ParticleManager => particleManager ? particleManager : Core.GetCoreComponent(ref particleManager);
        private ParticleManager particleManager;
        
        private Stats Stats => stats ? stats : Core.GetCoreComponent(ref stats);
        private Stats stats;

        private void Die()
        {
            if (!Core.transform.parent.CompareTag("Enemy"))
            {
                Core.transform.parent.gameObject.SetActive(false);
                return;
            }
            
            foreach (var particle in deathParticles)
            {
                ParticleManager.StartParticle(particle);
            }
            
            Core.transform.parent.gameObject.SetActive(false);
        }
        
        private void OnEnable()
        {
            Stats.OnHealthZero += Die;
        }

        private void OnDisable()
        {
            Stats.OnHealthZero -= Die;
        }
    }
}
