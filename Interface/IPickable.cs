using System;
namespace SwinFarm
{
    public interface IPickable
    {
        public abstract bool IsPicked();
        public abstract void Pick();
        public abstract void Unpick();
    }
}

