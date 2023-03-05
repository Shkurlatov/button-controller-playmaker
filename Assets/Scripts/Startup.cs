using System;
using UnityEngine;
using HutongGames.PlayMaker;

public class Startup : MonoBehaviour
{
    [SerializeField] private FsmTemplate _buttonControllerTemplate;
    [SerializeField] private float _buttonDelayInSeconds;

    private GameObject _button;
    private PlayMakerFSM _fsm;
    private FsmFloat _delayInSeconds;

    void Awake()
    {
        _button = GameObject.FindWithTag("Button");

        if (_button == null) throw new ArgumentNullException(nameof(_button));
        if (_buttonControllerTemplate == null) throw new UnassignedReferenceException($"{typeof(FsmTemplate)} has not been assigned to {nameof(_buttonControllerTemplate)}");
        if (_buttonDelayInSeconds < 0) throw new ArgumentOutOfRangeException($"{nameof(_buttonDelayInSeconds)} must be positive");
    }

    void Start()
    {
        SetupButton();
    }

    private void SetupButton()
    {
        _fsm = _button.AddComponent<PlayMakerFSM>();
        _fsm.SetFsmTemplate(_buttonControllerTemplate);
        _delayInSeconds = _fsm.FsmVariables.GetFsmFloat("delayInSeconds");
        _delayInSeconds.Value = _buttonDelayInSeconds;
    }
}
