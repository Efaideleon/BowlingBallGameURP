using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject _controlsPanel;
    [SerializeField] private InputReader _inputReader;

    void OnEnable() {
        _inputReader.OnMenuOpen += ToggleControlsPanel;
    }

    void OnDisable() {
        _inputReader.OnMenuOpen -= ToggleControlsPanel;
    }

    private void ToggleControlsPanel() => _controlsPanel.SetActive(!_controlsPanel.activeSelf);
    private void DisableControlsPanel() => _controlsPanel.SetActive(false);
}