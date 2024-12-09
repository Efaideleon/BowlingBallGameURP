using UnityEngine;

public class UpdateAspectRatio : MonoBehaviour
{
    public Material reflectionMaterial; // Assign the material using the shader graph
    private void Update()
    {
        float aspectRatio = (float)Screen.width / Screen.height;
        //reflectionMaterial.SetFloat("_Width", (float)Screen.height);
        reflectionMaterial.SetFloat("_AspectRatio", aspectRatio);
    }
}
