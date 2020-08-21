using ProjectCaravan.Core;
using UnityEngine;

public class CameraControllerX : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private float heightModifier = 1;
    [SerializeField] private float lerpSpeed = 1;
    private Controls ctrl;

    private Vector3 p;

    void Start()
    {
        ctrl = new Controls();
        ctrl.Enable();
    }

    void Update()
    {
        Vector2 moveDir = ctrl.Gameplay.MoveCamera.ReadValue<Vector2>();
        var camTrans = Camera.main.transform;
        var x = camTrans.right.normalized * moveDir.x;
        var y = (camTrans.forward - Vector3.up * camTrans.forward.y).normalized * moveDir.y;

        var camY = Camera.main.transform.position.y;

        p += (x + y) * (movementSpeed + camY * heightModifier);

        transform.position = Vector3.Lerp(transform.position, p, Time.deltaTime * lerpSpeed);
    }
}
