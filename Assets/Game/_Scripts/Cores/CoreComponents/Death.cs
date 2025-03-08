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

        public void Die()
        {
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
