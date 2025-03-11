using UnityEngine;

namespace Game.Scripts.Enemies.States.Data
{
    [CreateAssetMenu(fileName = "newLookForPlayerStateConfig", menuName = "Config/Enemy State Config/Look For Player State")]
    public class LookForPlayerConfig : ScriptableObject
    {
        public int amountOfTurns = 2;
        public float timeBetweenTurns = 0.75f;
    }
}
