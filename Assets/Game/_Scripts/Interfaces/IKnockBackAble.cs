using UnityEngine;

namespace Game.Scripts.Interfaces
{
    public interface IKnockBackAble
    {
        void KnockBack(Vector2 angle, float strength, int direction);
    }
}
