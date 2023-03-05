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
        _fsm = _button.AddComponent<PlayMakerFSM>();
        _fsm.SetFsmTemplate(_buttonControllerTemplate);
        _delayInSeconds = _fsm.FsmVariables.GetFsmFloat("delayInSeconds");
        _delayInSeconds.Value = _buttonDelayInSeconds;
    }
}
