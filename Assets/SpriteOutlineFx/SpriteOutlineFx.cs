using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/2D Sprite/Outline")]
public class SpriteOutlineFx : MonoBehaviour
{
    [SerializeField] Color _outlineColor = Color.red;

    public Color outlineColor {
        get { return _outlineColor; }
        set { _outlineColor = value; }
    }

    [SerializeField] float _sampleDistance = 2;

    public float sampleDistance {
        get { return _sampleDistance; }
        set { _sampleDistance = value; }
    }

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

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Setup();

        _material.SetFloat("_Distance", _sampleDistance);
        _material.SetColor("_Color", _outlineColor);

        Graphics.Blit(source, destination, _material);
    }
}
