using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [Header("Configuration")]
    public GameObject PlayerPrefab;
    public bool SpawnPlayerOnInput = true;

    [Header("Debugging")]
    public Spawner Spawner;
    public GameObject ControlledPlayer;
    public Vector2 MoveInput;
    public Vector2 MousePosition;
    public bool AInputDown;
    public bool XInputDown;
    public bool YInputDown;
    public bool BInputDown;
    public bool RightSpecialDown;
    public bool LeftSpecialDown;

    void Start()
    {
        Spawner = FindObjectOfType<Spawner>();

        if (Spawner == null)
        {
            Debug.LogError("InputHandler: Place a Spawn Handler in the scene");
        }
        else
        {
            Spawner.ObjectToSpawn = PlayerPrefab;

            if (SpawnPlayerOnInput == true)
            {
                SpawnPlayer();
            }
        }       
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void GetMousePosition()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);   
    }

    public void OnJumpSelect(InputAction.CallbackContext context)
    {
        AInputDown = context.performed;
    }

    public void OnX(InputAction.CallbackContext context)
    {
        XInputDown = context.performed;

    }

    public void OnY(InputAction.CallbackContext context)
    {
        YInputDown = context.performed;

    }

    public void OnB(InputAction.CallbackContext context)
    {
        BInputDown = context.performed;
    }

    public void OnSpecialRight(InputAction.CallbackContext context)
    {
        RightSpecialDown = context.performed;
    }

    public void OnSpecialLeft(InputAction.CallbackContext context)
    {
        LeftSpecialDown = context.performed;
    }

    public void SpawnPlayer()
    {
        if (PlayerPrefab != null)
        {
            ControlledPlayer = Spawner.Spawn();

            ConnectInputsToGO(ControlledPlayer);
        }
    }

    public void ConnectInputsToGO(GameObject _GO)
    {
        IInputConnectable[] inputConnections = _GO.GetComponents<IInputConnectable>();

        foreach (IInputConnectable IIC in inputConnections)
        {
            IIC.ConnectInput(this);
        }
    }

    public void DisconnectInputsFromGO(GameObject _GO)
    {
        IInputConnectable[] inputConnections = _GO.GetComponents<IInputConnectable>();

        foreach (IInputConnectable IIC in inputConnections)
        {
            IIC.ConnectInput(this);
        }
    }
}
