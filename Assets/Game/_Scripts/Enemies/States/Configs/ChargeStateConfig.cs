using UnityEngine;

namespace Game._Scripts.Enemies.States.Configs
{
    [CreateAssetMenu(fileName = "newChargeStateConfig", menuName = "Config/Enemy State Config/Charge State")]
    public class ChargeStateConfig : ScriptableObject
    {
        public float chargeSpeed = 6f;

        public float chargeTime = 2f;
    }
}
