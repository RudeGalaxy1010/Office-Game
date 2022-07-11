using System.Collections;
using System.Linq;
using UnityEngine;

public class WorkPlaceManager : MonoBehaviour
{
    [SerializeField] private PlayerInteraction _player;
    [SerializeField] private WorkPlace[] _workPlaces;
    [SerializeField] private float _delay;

    public void Init()
    {
        foreach (var workPlace in _workPlaces)
        {
            workPlace.Init(_player);
        }

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

        WorkPlace randomPlace = null;

        do
        {
            randomPlace = _workPlaces[Random.Range(0, _workPlaces.Length)];
        }
        while (randomPlace.TryChooseForIncident() == false);
    }

    private bool HasFreePlace()
    {
        return _workPlaces.FirstOrDefault(p => p.IsIncident == false);
    }
}
