using UnityEngine;

public class NameStand : MonoBehaviour
{
    private void OnGUI()
    {
        transform.LookAt(Camera.main.transform);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y + 180, transform.eulerAngles.z);
    }
}
