using UnityEngine;

[ExecuteInEditMode]
public class FitToTextureSize : MonoBehaviour
{
    public float pixelsPerUnit = 100f;
    public bool applyOnStart = true;

    void Start()
    {
        if (!Application.isPlaying) return;
        if (applyOnStart) FitSize();
    }

    [ContextMenu("Fit Size to Texture")]
    public void FitSize()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend == null) return;

        Material mat = Application.isPlaying ? rend.material : rend.sharedMaterial;
        if (mat == null || mat.mainTexture == null) return;

        Texture tex = mat.mainTexture;
        float texWidth = tex.width;
        float texHeight = tex.height;

        float targetWidth = texWidth / pixelsPerUnit;
        float targetHeight = texHeight / pixelsPerUnit;

        Vector3 currentSize = rend.bounds.size;

        float scaleX = targetWidth / currentSize.x;
        float scaleY = targetHeight / currentSize.y;

        transform.localScale = new Vector3(scaleX, scaleY, scaleX);
    }
}
