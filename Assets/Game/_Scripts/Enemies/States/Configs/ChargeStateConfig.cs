using UnityEngine;

namespace Game.Scripts.Enemies.States.Data
{
    [CreateAssetMenu(fileName = "newChargeStateData", menuName = "Data/State Data/Charge State")]
    public class ChargeStateConfig : ScriptableObject
    {
        public float chargeSpeed = 6f;

        public float chargeTime = 2f;
    }
}
