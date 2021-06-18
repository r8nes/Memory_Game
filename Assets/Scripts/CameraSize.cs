using UnityEngine;

public class CameraSize : MonoBehaviour
{
    private const float TargetSizeX = 1280f;
    private const float TargetSizeY = 720f;
    private const float HalfSize = 200f;

    private void Awake()
    {
        CameraResize();
    }
    private void CameraResize() {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = TargetSizeX / TargetSizeY;

        if (screenRatio>=targetRatio)
        {
            Resize();
        }
        else
        {
            float differentSize = targetRatio / screenRatio;
            Resize(differentSize);
        }
    }

    private static void Resize(float differentSize = 1.0f)
    {
        Camera.main.orthographicSize = TargetSizeY / HalfSize*differentSize;
    }
}
