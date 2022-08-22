using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AcceptorHandler : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;

    private Acceptor[] _accepters;
    private int _counter;

    private void Awake()
    {
        _winScreen.SetActive(false);
        _accepters = GetComponentsInChildren<Acceptor>();

        foreach (var accepter in _accepters)
        {
            accepter.DisableAcceptor();
        }

        _accepters[0].EnableAcceptor();
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

    public bool TryGetIncompleteAcceptor(out Acceptor acceptor)
    {
        acceptor = _accepters.FirstOrDefault(accepter => accepter.IsCompleted == false);
        return acceptor != null;
    }

    public IEnumerable<Acceptor> GetIncomplteAccepters()
    {
        var accepters = _accepters.ToList().FindAll(accepter => accepter.IsCompleted == false);

        return accepters;
    }

    private void OpenNextAccepter(Acceptor accepter)
    {
        accepter.Completed -= OpenNextAccepter;
        _counter++;

        if (_counter < _accepters.Length)
            _accepters[_counter].EnableAcceptor();

        if (_counter >= _accepters.Length)
            _winScreen.SetActive(true);
    }
}
