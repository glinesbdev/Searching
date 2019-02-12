using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerReceiveItemState : IState
    {
        Player player;

        public PlayerReceiveItemState(Player playerGameObject, GameObject itemReceieved)
        {
            player = playerGameObject;
            player.receivedItem.GetComponent<SpriteRenderer>().sprite = itemReceieved.GetComponent<SpriteRenderer>().sprite;
        }

        public void Enter()
        {
            player.animator.SetBool(PlayerAnimatorParametersEnum.ReceiveItem, true);
            player.receivedItem.SetActive(true);
        }

        public void Execute() { }

        public void Exit()
        {
            player.animator.SetBool(PlayerAnimatorParametersEnum.ReceiveItem, false);
            player.receivedItem.SetActive(false);
        }
    }
}