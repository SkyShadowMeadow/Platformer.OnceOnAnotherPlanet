using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParallaxBackground : MonoBehaviour
{
    public ParallaxCamera parallaxCamera;
    List<ParallaxLayer> parallaxLayers = new List<ParallaxLayer>();

    void Start()
    {
        if (parallaxCamera == null)
            parallaxCamera = Camera.main.GetComponent<ParallaxCamera>();
        if (parallaxCamera != null)
            parallaxCamera.onCameraTranslate += Move;
        SetLayers();
    }

    void SetLayers()
    {
        parallaxLayers.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform BigLayer = transform.GetChild(i);
            for (int j = 0; j < transform.childCount; j++)
            {
                ParallaxLayer layer = BigLayer.GetChild(j).GetComponent<ParallaxLayer>();
                if (layer != null)
                {
                    layer.name = "Layer-" + i;
                    parallaxLayers.Add(layer);
                }
            }
        }
    }
    void Move(float delta)
    {
        foreach (ParallaxLayer layer in parallaxLayers)
        {
            layer.Move(delta);
        }
    }
}
