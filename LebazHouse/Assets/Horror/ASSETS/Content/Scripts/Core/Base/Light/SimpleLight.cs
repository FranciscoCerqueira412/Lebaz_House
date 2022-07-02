﻿using UnityEngine;

public class SimpleLight : MonoBehaviour {

    public enum LightType { Static, SwitchControlled, Flickering }

    private Animation anim;
    private MeshRenderer meshRenderer;

    public LightType lightType = LightType.Static;

    public Light lightObj;
    public Electricity electricity;
    public InteractiveLight interactiveLight;

    void Awake()
    {
        if (lightType == LightType.Flickering)
        {
            if (GetComponent<Animation>())
            {
                anim = GetComponent<Animation>();
            }
            else if (lightObj.GetComponent<Animation>())
            {
                anim = lightObj.GetComponent<Animation>();
            }
            else
            {
                Debug.LogError($"[SimpleLight] {gameObject.name} Could not find Animation Script!");
            }
        }

        meshRenderer = GetComponent<MeshRenderer>();
    }

	void Update () {
        if (lightType == LightType.Flickering)
        {
            if (anim && !anim.isPlaying)
            {
                if (electricity)
                {
                    if (electricity.isPoweredOn)
                    {
                        anim.Play();
                        lightObj.enabled = true;
                    }
                    else
                    {
                        anim.Stop();
                        lightObj.enabled = false;
                    }
                }
                else
                {
                    anim.Play();
                    lightObj.enabled = true;
                }
            }
        }
        else if (lightType == LightType.SwitchControlled)
        {
            lightObj.enabled = interactiveLight.isPoweredOn;
        }
        else if (electricity)
        {
            lightObj.enabled = electricity.isPoweredOn;
        }

        foreach (var material in meshRenderer.materials)
        {
            if (lightObj.enabled)
            {
                material.SetColor("_EmissionColor", new Color(1f, 1f, 1f));
            }
            else
            {
                material.SetColor("_EmissionColor", new Color(0f, 0f, 0f));
            }
        }
    }
}