using System;

namespace Game
{
    public class PlayerInteractState : IState
    {
        Player player;
        Action<IPlayerInteractor> afterExitCallback;
        IPlayerInteractor interactor;

        public PlayerInteractState(Player playerGameObject, IPlayerInteractor interactorClass, Action<IPlayerInteractor> afterExit)
        {
            player = playerGameObject;
            afterExitCallback = afterExit;
            interactor = interactorClass;
        }

        public void Enter() { }

        public void Execute()
        {
            if (player.interactedObject != null)
            {
                player.interactedObject.Interact();
            }
            else
            {
                player.stateMachine.ChangeState(new PlayerMoveState(player));
            }
        }

        public void Exit()
        {
            afterExitCallback(interactor);
        }
    }

    public interface IPlayerInteractor
    {
        void AfterCallback(IPlayerInteractor interactor);
    }
}