using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Animator))]
    public class TreasureChest : PlayerInteractable
    {
        public GameObject contents;

        Animator animator;

        public override void AnimationInteraction()
        {
            base.AnimationInteraction();
            animator.SetBool("Open", true);
            StartCoroutine(WaitForAnimationCo(GetAnimationTimeInSeconds("Open")));
        }

        public override void DialogInteraction()
        {
            base.DialogInteraction();
            dialogTextObject.text = dialogText;
            isInteracting = false;
        }

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        IEnumerator WaitForAnimationCo(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            hasAnimated = true;
            canInteract = isInteracting = false;

            if (isDialog)
            {
                ActivateDialogBox();
            }

            player.stateMachine.ChangeState(new PlayerReceiveItemState(player, contents));
        }

        float GetAnimationTimeInSeconds(string animationName)
        {
            // Set default wait for animation time
            float animationTime = 0.5f;

            AnimationClip[] animations = animator.runtimeAnimatorController.animationClips;
            for (int i = 0; i < animations.Length; i++)
            {
                if (animations[i].name == animationName)
                {
                    // Adding a bit of a buffer so it's not returning the INSTANT that it's finished
                    animationTime = animations[i].length + 0.1f;
                    break;
                }
            }

            return animationTime;
        }
    }
}