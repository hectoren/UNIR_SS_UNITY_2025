using UnityEngine;
using UnityEngine.InputSystem;

public class PauseController : MonoBehaviour
{
    [SerializeField] private InputActionReference pauseAction;

    private void OnEnable()
    {
        pauseAction.action.Enable();
        pauseAction.action.started += OnPause;
    }

    private void OnDisable()
    {
        pauseAction.action.started -= OnPause;
        pauseAction.action.Disable();
    }

    private void OnPause(InputAction.CallbackContext ctx)
    {
        GameManager.Instance.TogglePause();
    }
}
