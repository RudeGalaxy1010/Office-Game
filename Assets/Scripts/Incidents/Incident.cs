using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incident : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particleSystems;
    [SerializeField] private IncidentType _type;

    public void Enable()
    {
        foreach (var particleSystem in _particleSystems)
        {
            particleSystem.Play();
        }
    }

    public void Disable()
    {
        foreach (var particleSystem in _particleSystems)
        {
            particleSystem.Stop();
        }
    }
}
