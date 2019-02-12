using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public interface IState
    {
        void Enter();
        void Execute();
        void Exit();
    }
}