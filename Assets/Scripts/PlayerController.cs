using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  A REVOIR
 * 
 */
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;

    public CharacterController controller;


    void Start () {
	}
	
	void Update () {
        HandleMovementInput();
    }

    void HandleMovementInput()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        Vector3 _direction = new Vector3(_horizontal, 0, _vertical).normalized;

        if(_direction.magnitude >= 0.1f )
        {
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            
            controller.Move(_direction * movementSpeed * Time.deltaTime);
        }

    }

    void HandleRotationInput()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(_ray, out _hit))
        {
            transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
        }
    }

    
}
