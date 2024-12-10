using UnityEngine;
using UnityEngine.UI;
using player;

public class PowerBar : MonoBehaviour {
    [SerializeField] private Slider _powerBarSlider;
    [SerializeField] private GameObject _powerBarContainer;
    [SerializeField] private Material _material; 
    [SerializeField] PlayerController _playerController;

    private float ChargePercentage => _playerController.ChargedThrowAction.ChargePercentage;
    private float customTime = 0;
    private float speed = 0.2f;
    void Start() {
        _powerBarContainer.SetActive(false);
    }

    void Update() {

        if (ChargePercentage > 0) {
            customTime += Time.deltaTime * speed * ChargePercentage;
            _material.SetFloat("_CustomTime", customTime);

            SetPowerBarVisibility(true);
            if (_powerBarSlider != null) {
                _powerBarSlider.value = ChargePercentage; // Set the slider value
            }
            if (_material != null) {
                _material.SetFloat("_GradientHue", ChargePercentage); // Update material property
            }
        }
        else {
            SetPowerBarVisibility(false);
            customTime = 0;
            if (_powerBarSlider != null) {
                _powerBarSlider.value = 0; // Reset slider value
                if (_material != null) {
                    _material.SetFloat("_GradientHue", 0); // Update material property
                }
            }
        }
    }

    private void SetPowerBarVisibility(bool isVisible) {
        if (_powerBarContainer != null) {
            _powerBarContainer.SetActive(isVisible);
        }
        else {
            Debug.LogWarning("Power bar container is not assigned");
        }
    }
}