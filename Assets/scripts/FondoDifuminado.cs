using UnityEngine;
using UnityEngine.UI;

public class FondoDifuminado : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Camera camaraPrincipal;   // arrastrá tu Main Camera
    [SerializeField] private RawImage imagenFondo;      // arrastrá el RawImage que creaste

    [Header("Config del blur")]
    [Range(2, 20)]
    [SerializeField] private int downscale = 8; // mas alto = mas blur, menos alto = mas nitido

    private RenderTexture rt;

    public void CapturarYDifuminar()
    {
        int ancho = Mathf.Max(1, Screen.width / downscale);
        int alto = Mathf.Max(1, Screen.height / downscale);

        // liberamos la anterior si existia, para no dejar basura en memoria
        if (rt != null)
        {
            rt.Release();
        }

        rt = new RenderTexture(ancho, alto, 16);
        rt.filterMode = FilterMode.Bilinear; // esto es lo que genera el efecto de blur al estirarse

        RenderTexture texturaAnterior = camaraPrincipal.targetTexture;
        camaraPrincipal.targetTexture = rt;
        camaraPrincipal.Render();
        camaraPrincipal.targetTexture = texturaAnterior;

        imagenFondo.texture = rt;
    }

    private void OnDestroy()
    {
        if (rt != null)
        {
            rt.Release();
        }
    }
}