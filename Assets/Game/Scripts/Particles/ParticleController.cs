using UnityEngine;

namespace Game.Scripts.Particles
{
    public class ParticleController : MonoBehaviour
    {
        public void FinishAnimation()
        {
            Destroy(gameObject);
        }
    }
}
