using UnityEngine;

namespace Game._Scripts.Interfaces
{
    public interface IKnockBackAble
    {
        void KnockBack(Vector2 angle, float strength, int direction);
    }
}
