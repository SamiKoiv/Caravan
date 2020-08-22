using ProjectCaravan.Core.Input;
using UnityEngine;

public class CameraControllerY : MonoBehaviour
{
    [SerializeField] private float scrollSensitivity = 1;
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private float maxHeight = 1;
    [SerializeField] private float minHeight = 1;
    private Controls ctrl;

    private float h;

    void Start()
    {
        ctrl = new Controls();
        ctrl.Enable();
    }

    void Update()
    {
        Vector2 scrollDir = ctrl.Gameplay.ZoomCamera.ReadValue<Vector2>() * scrollSensitivity;

        h = Mathf.Clamp(h -scrollDir.y, minHeight, maxHeight);

        transform.position = Vector3.Lerp( transform.position, new Vector3(transform.position.x, h, transform.position.z), Time.deltaTime * movementSpeed);
    }
}
