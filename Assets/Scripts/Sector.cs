using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsGood = true;
    public Material GoodMaterial;
    public Material BadMaterial;
    public Rigidbody Rigidbody;
    public Collider Collider;
    public bool FadingOut = false;
    public ActivateParticles ActivateParticles;
    private float FadeAmount;
    private float FadeSpeed;
    private Material _AlphaMaterial;
    private float _Alpha = 1f;
    

    private void Awake()
    {
        UpdateMaterial();
        _AlphaMaterial = GetComponent<Renderer>().material;
    }

    private void UpdateMaterial()
    {
        Renderer sectorRenderer = GetComponent<Renderer>();
        sectorRenderer.sharedMaterial = IsGood ? GoodMaterial : BadMaterial;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;

        Vector3 normal = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.up);
        if (dot < 0.5) return;
        if (IsGood)
            player.Bounce();
        else
            player.Die();
    }

    private void OnValidate()
    {
        UpdateMaterial();
    }

    public void SectorBurst(float distanceForward, float distanceUp, float fadeSpeed)
    {
        Rigidbody.velocity = transform.forward * distanceForward + transform.up * distanceUp;
        Rigidbody.isKinematic = false;
        Collider.enabled = false;
        FadingOut = true;
        FadeSpeed = fadeSpeed;
    }

    public void Fading(float fadeSpeed)
    {
        /*Color fadeSectorColor = this.GetComponent<Renderer>().material.color;
        FadeAmount = fadeSectorColor.a - (fadeSpeed * Time.deltaTime);

        fadeSectorColor = new Color(fadeSectorColor.r, fadeSectorColor.g, fadeSectorColor.b, FadeAmount);
        GetComponent<Renderer>().material.color = fadeSectorColor;*/

        _Alpha = _Alpha - (fadeSpeed/1.5f) * Time.deltaTime;
        _AlphaMaterial.SetFloat("_Alpha", _Alpha);
        ActivateParticles.SetEmissionActive();
        if (_Alpha <= 0)
        {
            FadingOut = false;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(FadingOut)
        {
            Fading(FadeSpeed);
        }
    }
}
