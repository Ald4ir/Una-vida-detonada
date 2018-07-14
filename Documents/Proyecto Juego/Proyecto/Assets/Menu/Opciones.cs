using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Opciones : MonoBehaviour
{
    public Scrollbar scroll;
    public AudioMixer AudioMixer;
    public Dropdown resolutionsDropdown;
    Resolution[] resolutions;
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();
        List<string> Options = new List<string>();
        int CurrentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            Options.Add(option);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                CurrentResolutionIndex = i;
            }
        }
        resolutionsDropdown.AddOptions(Options);
        resolutionsDropdown.value = CurrentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
    }
    public void setResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void CambiarBrillo()
    {
        RenderSettings.ambientIntensity = scroll.value;
    }
    public void CambiarVolumen(float volumen)
    {
        Debug.Log("Cambiar volumen");
        AudioMixer.SetFloat("Volume", volumen * 10);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}