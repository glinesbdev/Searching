using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerMoveState : IState
    {
        Player player;

        public PlayerMoveState(Player playerGameObject)
        {
            player = playerGameObject;
        }

        public void Enter()
        {
            if (player.speed.value < 0.1f)
            {
                player.speed.value = 4f;
            }
        }

        public void Execute()
        {
            player.movement = Vector3.zero;
            player.movement.x = Input.GetAxisRaw("Horizontal");
            player.movement.y = Input.GetAxisRaw("Vertical");

            if (player.movement != Vector3.zero)
            {
                UpdateMovementWithAnimation();
            }
            else
            {
                player.animator.SetBool(PlayerAnimatorParametersEnum.Walking, false);
            }
        }

        public void Exit()
        {
            player.animator.SetBool(PlayerAnimatorParametersEnum.Walking, false);
        }

        void UpdateMovementWithAnimation()
        {
            player.animator.SetBool(PlayerAnimatorParametersEnum.Walking, true);
            player.animator.SetFloat(PlayerAnimatorParametersEnum.MoveX, player.movement.x);
            player.animator.SetFloat(PlayerAnimatorParametersEnum.MoveY, player.movement.y);

            player.movement.Normalize();
            player.rigidBody.MovePosition(player.transform.position + player.movement * player.speed.value * Time.deltaTime);
        }
    }
}