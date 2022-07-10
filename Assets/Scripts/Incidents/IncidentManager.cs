using System.Collections;
using System.Linq;
using UnityEngine;

public class IncidentManager : MonoBehaviour
{
    [SerializeField] private IncidentPlace[] _places;
    [SerializeField] private float _delay;

    public void StartCreatingIncidents()
    {
        StartCoroutine(CreateIncidents());
    }

    private IEnumerator CreateIncidents()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            CreateRandomIncident();
        }
    }

    private void CreateRandomIncident()
    {
        if (HasFreePlace() == false)
        {
            return;
        }

        IncidentPlace randomPlace = null;

        do
        {
            randomPlace = _places[Random.Range(0, _places.Length)];
        }
        while (randomPlace.TrySetRandomIncident() == false);
    }

    private bool HasFreePlace()
    {
        return _places.FirstOrDefault(p => p.IsIncident == false);
    }
}
