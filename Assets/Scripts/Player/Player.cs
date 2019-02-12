using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Animator))]
    public class Player : MonoBehaviour
    {
        [HideInInspector] public Rigidbody2D rigidBody;
        [HideInInspector] public Animator animator;
        [HideInInspector] public Vector3 movement;
        [HideInInspector] public StateMachine stateMachine;
        [HideInInspector] public PlayerInteractable interactedObject;
        public GameObject receivedItem;
        public FloatValue speed;

        void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        void Start()
        {
            animator.SetFloat("MoveX", 0f);
            animator.SetFloat("MoveY", -1f);

            stateMachine = new StateMachine();
            stateMachine.ChangeState(new PlayerMoveState(this));
        }

        void Update()
        {
            stateMachine.ExecuteState();
        }
    }
}
