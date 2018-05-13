using UnityEngine;

public class PlayerControllerSimple : MonoBehaviour
{
	public float WalkSpeed = 1f;
	private CharacterController _character;

	private void Start() {
		_character = GetComponent<CharacterController>();
	}

	private void FixedUpdate() {
		Vector3 inputMovement =
			new Vector3(
					Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"))
				.normalized;

		var inputVelocity = inputMovement * WalkSpeed;
		var playerVelocity = inputVelocity.x * transform.right +
		                     inputVelocity.z * transform.forward;

		var distance = playerVelocity * Time.fixedDeltaTime;
		_character.Move(distance);
	}
}
