using UnityEngine;

public class MirrorReflection : MonoBehaviour
{
    public Camera mainCamera;
    public Camera reflectionCamera;

    void Update()
    {
        if (reflectionCamera == null || mainCamera == null) return;

        // Position the reflection camera
        Vector3 cameraPosition = mainCamera.transform.position;
        reflectionCamera.transform.position = new Vector3(
            cameraPosition.x,
            -cameraPosition.y,
            cameraPosition.z
        );

        // Reflect the camera's rotation
        Vector3 eulerAngles = mainCamera.transform.eulerAngles;
        reflectionCamera.transform.eulerAngles = new Vector3(
            -eulerAngles.x,
            eulerAngles.y,
            0
        );
    }
}
