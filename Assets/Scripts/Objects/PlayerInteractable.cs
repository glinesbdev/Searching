using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class PlayerInteractable : MonoBehaviour, IPlayerInteractable, IPlayerInteractor
    {
        [HideInInspector] public bool hasAnimated;
        [HideInInspector] public Player player;
        [SerializeField] bool isAnimated;
        [Tooltip("Enable this is an interactable object can be interacted with mulitple times.")]
        [SerializeField] bool reInteractable;
        public bool isDialog;
        public Image dialogBox;
        public Text dialogTextObject;
        public string dialogText;

        [HideInInspector] public bool canInteract;
        [HideInInspector] public bool isInteracting;

        public void Interact()
        {
            if (!isAnimated && !isDialog)
            {
                string error = $"This interactable, {gameObject.name}, must either have Is Animated or Is Dialog set to True in the instance script variables!";
                Debug.LogError(error);
                return;
            }

            if (isAnimated && isDialog && !hasAnimated)
            {
                AnimationInteraction();
                DialogInteraction();
            }
            else if (isAnimated && !hasAnimated)
            {
                AnimationInteraction();
            }
            else
            {
                DialogInteraction();
            }
        }

        public virtual void AnimationInteraction()
        {
            isInteracting = true;
        }

        public virtual void DialogInteraction()
        {
            isInteracting = true;
        }

        public void AfterCallback(IPlayerInteractor interactor)
        {
            if (reInteractable)
            {
                canInteract = true;
            }
        }

        public void ActivateDialogBox()
        {
            if (!dialogBox.gameObject.activeInHierarchy)
            {
                dialogBox.gameObject.SetActive(true);

            }
        }

        void Awake()
        {
            canInteract = true;
            dialogBox.gameObject.SetActive(false);
        }

        void Update()
        {
            if (Input.GetButtonDown("Interact") && player != null)
            {
                if (canInteract && !isInteracting)
                {
                    player.stateMachine.ChangeState(new PlayerInteractState(player, this, AfterCallback));
                }
                else
                {
                    dialogBox.gameObject.SetActive(false);
                    player.stateMachine.ChangeState(new PlayerMoveState(player));
                }
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                if (canInteract)
                {
                    player = collision.gameObject.GetComponent<Player>();
                    player.interactedObject = this;
                }
            }
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                // In case the trigger fires after the player is null
                if (player != null)
                {
                    player.interactedObject = null;
                    player = null;
                }
            }
        }
    }
}