using UniRx;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float WalkSpeed = 1f;
    private CharacterController _character;
    
    private void Start()
    {
        var inputs = Inputs.Instance;

        _character = GetComponent<CharacterController>();

        inputs.Movement
            .Where(v => v != Vector2.zero)
            .Subscribe(inputMovement =>
            {
                var inputVelocity = inputMovement * WalkSpeed;
                var playerVelocity =
                    inputVelocity.x * transform.right +
                    inputVelocity.y * transform.forward;
                var distance = playerVelocity * Time.fixedDeltaTime;
                _character.Move(distance);
            }).AddTo(this);

    }
}
