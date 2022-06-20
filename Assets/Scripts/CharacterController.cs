using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.CharacterController controller;
    [SerializeField]
    private float movementSpeed;

    private void Start()
    {

    }

    void Update()
    {
        HandleMovementInput();
        HandleRotationInput();
    }

    void HandleMovementInput()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        // Force diagonal movement speed same as horizontal or vertical
        if(move.magnitude > 1)
        {
            move /= move.magnitude;
        }

        controller.Move(move * Time.deltaTime * movementSpeed);
    }

    void HandleRotationInput()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
        }
    }


}
