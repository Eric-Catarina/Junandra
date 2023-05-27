using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private SoundManager soundManager;
    
    [SerializeField]
    private Slider musicSlider, sfxSlider, generalSlider;

    [SerializeField]
    private GameObject optionsPanel;
    


    void Awake()
    {
        //soundManager.MusicVolumeInitialized += SetMusicSliderValue;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {
        //soundManager.MusicVolumeInitialized -= SetMusicSliderValue;
    }

    public void SetMusicSliderValue(float value)
    {
        musicSlider.value = value;
    }
    public void SetSFXSliderValue(float value)
    {
        sfxSlider.value = value;
    }
    public void SetGeneralSliderValue(float value)
    {
        generalSlider.value = value;
    }

    public void OpenOptionsPanel()
    {
        optionsPanel.SetActive(true);
    }
    public void CloseOptionsPanel()
    {
        optionsPanel.SetActive(false);
    }

}
