///handle player movement for first person with mouse and keyboard controls

using UnityEngine;

public class PlayerMovement : MonoBehaviour {

  private Rigidbody rb;
  private Vector3 walk;

  [SerializeField] private float walkSpeed = 5f;

  [SerializeField] private float mouseSensitivity = 10f;
  [SerializeField] private Transform playerCamera;

  private Vector3 rotation;

  public bool redTriggered = false;

  private void Start() {
    rb = GetComponent<Rigidbody>();

    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  private void Update() {

  }

  private void FixedUpdate() {
    CheckKeyInput();
    MovePlayer();

    FollowMouse();
  }

  private void CheckKeyInput() {
    walk = Vector3.zero;
    if (Input.GetKey(KeyCode.W)) {
      walk.z += 1;
    }
    if (Input.GetKey(KeyCode.S)) {
      walk.z -= 1;
    }
    if (Input.GetKey(KeyCode.D)) {
      walk.x += 1;
    }
    if (Input.GetKey(KeyCode.A)) {
      walk.x -= 1;
    }
  }

  private void MovePlayer() {
    Vector3 moveDirection = (transform.forward * walk.z + transform.right * walk.x).normalized;
    Vector3 targetPosition = rb.position + moveDirection * walkSpeed * Time.fixedDeltaTime;

    rb.MovePosition(targetPosition);
  }

  private void FollowMouse() {
    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
    float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

    // Rotate player horizontally
    transform.Rotate(Vector3.up * mouseX);

    // Rotate playerCamera vertically (clamped)
    rotation.x -= mouseY;
    rotation.x = Mathf.Clamp(rotation.x, -90f, 90f);

    playerCamera.localRotation = Quaternion.Euler(rotation.x, 0f, 0f);
  }

  public Vector3 GetPosition() {
    return transform.position;
  }

  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("RedTrigger")) {
      redTriggered = true;
    }
  }

}
