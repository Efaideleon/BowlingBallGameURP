using UnityEngine;
using state_machine;

namespace player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private InputReader _input;
        [SerializeField] private float _movementSpeed = 1f;

        private Animator _animator;
        private CharacterController _characterController;
        private StateMachine _stateMachine;
        private ChargedThrowActionPlayer _chargedThrowActionPlayer;

        private float _playerMovementLeftBound = -14.50f;
        private float _playerMovementRightBound = -12.90f;

        public ChargedThrowAction ChargedThrowAction => _chargedThrowActionPlayer.ChargedThrowAction;
        public Vector3 GetDirection() => _input.Direction;

        void Awake()
        {
            _animator = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();
            _stateMachine = StateMachineBuilder.Build(this, _animator);
            _chargedThrowActionPlayer = GetComponent<ChargedThrowActionPlayer>();
        }

        void Start() => Hold();
        void Update() => _stateMachine.Update();
        void FixedUpdate() => _stateMachine.FixedUpdate();

        public void HandleMovement()
        {
            Vector2 moveDirection = _input.Direction;

            if (transform.localPosition.x > _playerMovementRightBound && moveDirection.x == 1)
            {
                moveDirection.x = 0;
            }
            if (transform.localPosition.x < _playerMovementLeftBound && moveDirection.x == -1)
            {
                moveDirection.x = 0;
            }

            _characterController.Move(_movementSpeed * Time.deltaTime * moveDirection);
        }
        public void Hold() => ChargedThrowAction.Hold();
    }
}