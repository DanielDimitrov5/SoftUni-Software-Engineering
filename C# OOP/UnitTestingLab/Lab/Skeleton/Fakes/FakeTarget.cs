using System;
using Skeleton.Interfaces;

namespace Skeleton
{
    public class FakeTarget : ITarget
    {
        public int GiveExperience()
        {
            return 100;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {
        }
    }
}
