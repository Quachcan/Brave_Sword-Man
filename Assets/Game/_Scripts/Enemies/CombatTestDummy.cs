using Game.Scripts.Interfaces;
using UnityEngine;

namespace Game.Scripts.Enemies
{
    public class CombatTestDummy : MonoBehaviour, IDamageable
    {
        private static readonly int Hit = Animator.StringToHash("Hit");
        private Animator anim;
        
        [SerializeField] private GameObject hitParticles;
        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        public void Damage(float damage)
        {
            Debug.Log(damage +  " damage");
            
            Instantiate(hitParticles, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            //anim.SetTrigger(Hit);
            Destroy(gameObject);
        }
    }
}
