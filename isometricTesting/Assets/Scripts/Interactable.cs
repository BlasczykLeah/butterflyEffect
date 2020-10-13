using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private float outlineScaleFactor;
    [SerializeField] private Color outlineColor;
    public Renderer outlineRenderer;

    [Header("Other Highlight")]
    public GameObject[] objects;

    void Start()
    {
        outlineRenderer = CreateOutline(outlineMaterial, outlineScaleFactor, outlineColor);
    }

    Renderer CreateOutline(Material outlineMat, float scaleFactor, Color color)
    {

        GameObject outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform);
        Destroy(outlineObject.GetComponent<Rigidbody>());
        Renderer rend = outlineObject.GetComponent<Renderer>();
        rend.material = outlineMat;
        rend.material.SetColor("_OutlineColor", color);
        rend.material.SetFloat("_ScaleFactor", scaleFactor);
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        outlineObject.GetComponent<Interactable>().enabled = false;
        outlineObject.GetComponent<Collider>().enabled = false;
        rend.enabled = false;

        return rend;
    }

    public void enableHighlight(bool enable)
    {
        foreach (GameObject a in objects) a.SetActive(enable);
    }
}