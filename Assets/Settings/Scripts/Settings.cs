using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Toggle introToggle;
    [SerializeField] private Slider VolumeSlider;
    private void Start()
    {
        if (introToggle != null)
        {
            bool currentState = PlayerPrefs.GetInt("intro", 1) == 1;
            introToggle.isOn = currentState;
            introToggle.onValueChanged.AddListener(OnToggleValueChanged);
        }

        Load();
    }

    private void OnToggleValueChanged(bool isOn) =>
        PlayerPrefs.SetInt("intro", isOn ? 1 : 0);

    public void ChangeVolume()
    {
        AudioListener.volume = VolumeSlider.value;
        Save();
    }
    private void Load() => VolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    private void Save() => PlayerPrefs.SetFloat("musicVolume", VolumeSlider.value);
}
