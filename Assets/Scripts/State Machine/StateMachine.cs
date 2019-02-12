namespace Game
{
    public class StateMachine
    {
        IState currentState;
        IState previousState;

        public void ChangeState(IState state)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }

            previousState = currentState;
            currentState = state;
            currentState.Enter();
        }

        public void ExecuteState()
        {
            if (currentState != null)
            {
                currentState.Execute();
            }
        }

        public void ChangeToPreviousState()
        {
            currentState.Exit();
            currentState = previousState;
            currentState.Enter();
        }
    }
}