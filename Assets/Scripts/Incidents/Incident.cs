using UnityEngine;

public class Incident : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particleSystems;
    [SerializeField] private float _eliminatingTime;
    [SerializeField] private IncidentType _type;

    public float EliminatingTime => _eliminatingTime;

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
