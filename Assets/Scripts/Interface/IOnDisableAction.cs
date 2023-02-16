
using System;

namespace Interface
{
    public interface IOnDisableAction
    {
        public Action OnDisable { get; protected set; }
        void SetOnDisableAction();
    }
}
