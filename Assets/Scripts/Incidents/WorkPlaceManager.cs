using System.Collections;
using System.Linq;
using UnityEngine;

public class WorkPlaceManager : MonoBehaviour
{
    [SerializeField] private PlayerInteraction _player;
    [SerializeField] private WorkPlace[] _workPlaces;
    [SerializeField] private float _delay;

    private float _timer;
    private bool _isPause;

    public void Init()
    {
        foreach (var workPlace in _workPlaces)
        {
            workPlace.Init(_player);
        }

         _isPause = false;
    }

    public void Pause()
    {
        _isPause = true;
    }

    private void Update()
    {
        if (_isPause == true)
        {
            return;
        }

        _timer += Time.deltaTime;

        if (_timer >= _delay)
        {
            _timer = 0;
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
