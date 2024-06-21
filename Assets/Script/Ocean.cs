using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocean : MonoBehaviour
{
    [SerializeField] private GameObject ocean;
    [SerializeField] private float wavePower = 2f;

    private Material _oceanMat;
    private Texture2D _oceanTex;

    private void Start()
    {
        SetValue();
    }


    private void SetValue()
    {
        _oceanMat = ocean.GetComponent<Renderer>().sharedMaterial;
        _oceanTex = (Texture2D)_oceanMat.GetTexture("_mainTex");
    }

    private void OnValidate()
    {
        if (!Application.isPlaying) return;
        if (ocean != null)
        {
            SetValue();
        }
        _oceanMat.SetFloat("_wavePower",wavePower);
    }

    public float GetWaveHeight(Vector3 point)
    {
        float waveHeight = _oceanTex.GetPixelBilinear(point.x, point.z).g * wavePower;
        return waveHeight;
    }
}
