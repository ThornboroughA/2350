using System.Collections;
using System.Collections.Generic;
using TwentyThreeFifty.Propulsion;
using UnityEngine;

public class Propulsion_Inputs : MonoBehaviour
{

    [Tooltip("The thruster set associated with this input system.")]
    [SerializeField] ThrusterMainSystem associatedThrusterSet;

    private Vector2 movementInput;

    private MainControls mainControls;

    private float horizontalInput;
    private float verticalInput;

    private void OnEnable()
    {
        if (mainControls == null)
        {
            mainControls = new MainControls();

            mainControls.Locomotion.Movement.performed += i => movementInput = i.ReadValue<Vector2>();

        }
        mainControls.Enable();
    }
    private void OnDisable()
    {
        mainControls.Disable();
    }

    private void Update()
    {
        associatedThrusterSet.movementAmount = HandleMovementInput();
    }

    private Vector2 HandleMovementInput()
    {
        // Movement
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        return new Vector2(horizontalInput, verticalInput);
    }



}
