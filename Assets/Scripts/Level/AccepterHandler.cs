using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AccepterHandler : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;

    private Accepter[] _accepters;
    private int _counter;

    private void Awake()
    {
        _winScreen.SetActive(false);
        _accepters = GetComponentsInChildren<Accepter>();

        foreach (var accepter in _accepters)
        {
            accepter.DisableThisEbanieCollider();
        }

        _accepters[0].ActivateAndEnableThisEbanieCollider();
    }

    private void OnEnable()
    {
        foreach (var accepter in _accepters)
        {
            accepter.Completed += OpenNextAccepter;
        }
    }

    private void OnDisable()
    {
        foreach (var accepter in _accepters)
        {
            accepter.Completed -= OpenNextAccepter;
        }
    }

    public IEnumerable<Accepter> GetIncomplteAccepters()
    {
        var accepters = _accepters.ToList().FindAll(accepter => accepter.IsCompleted == false);

        return accepters;
    }

    private void OpenNextAccepter(Accepter accepter)
    {
        accepter.Completed -= OpenNextAccepter;
        _counter++;

        if(_counter<_accepters.Length)
            _accepters[_counter].ActivateAndEnableThisEbanieCollider();

        if (_counter >= _accepters.Length)
            _winScreen.SetActive(true);
    }
}
