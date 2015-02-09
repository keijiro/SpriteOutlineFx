using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/2D Sprite/Outline")]
public class SpriteOutlineFx : MonoBehaviour
{
    public Color outlineColor;
    public float sampleDistance;

    [SerializeField] Shader shader;

    Material _material;

    void Setup()
    {
        if (_material == null)
        {
            _material = new Material(shader);
            _material.hideFlags = HideFlags.DontSave;
        }
    }

    void Start()
    {
        Setup();
    }

    void OnValidate()
    {
        Setup();
    }

    void Reset()
    {
        Setup();
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Setup();

        _material.SetFloat("_Distance", sampleDistance);
        _material.SetColor("_Color", outlineColor);

        Graphics.Blit(source, destination, _material);
    }
}
