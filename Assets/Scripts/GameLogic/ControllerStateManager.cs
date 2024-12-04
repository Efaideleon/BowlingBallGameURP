using UnityEngine;

public enum GameState
{
    Start,
    Playing,
    Paused,
    None
}

public abstract class BaseState
{
    public abstract void OnEnter();

}

public class StartState : BaseState
{
    public override void OnEnter()
    {

    }
}

public class PlayingState : BaseState
{
    [SerializeField] private GameObject _canvas;

    public PlayingState(GameObject canvas)
    {
        _canvas = canvas;
    }

    public override void OnEnter()
    {
        _canvas.SetActive(true);
    }
}

public class ControllerStateManager : MonoBehaviour
{
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _canvas;
    private BaseState _currentObjectState;
    private GameState _currentState;

    public GameState CurrentGameState
    {
        get { return _currentState; }
        private set { _currentState = value; }
    }

    void Start()
    {
        CurrentGameState = GameState.Start;
    }

    void Update()
    {
        DetermineState();
    }
    private void DetermineState()
    {
        var newGameState = GameState.None;
        BaseState newObjectState;
        if (_startScreen.activeSelf)
        {
            newGameState = GameState.Start;
            newObjectState = new StartState();
        }
        else
        {
            newGameState = GameState.Playing;
            newObjectState =  new PlayingState(_canvas);
        }

        if (CurrentGameState != newGameState)
        {
            CurrentGameState = newGameState;
            _currentObjectState = newObjectState;
            _currentObjectState.OnEnter();
        }
    }
}