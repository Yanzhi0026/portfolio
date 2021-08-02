using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetUI : MonoBehaviour
{
    public Slider audioSlider;
    public Toggle audioMuteTgl;
    public Text audioTxt;
    private bool isOn = true;
    // Start is called before the first frame update
    void Start()
    {
        audioTxt.text = "60.0%";
        audioSlider.value = 0.6f;
        
    }

    // Update is called once per frame
    void Update()
    {
        vauleChange();
    }

    public void setMute()
    {
        if (isOn)
        {
            isOn = false;
        }
        else
        {
            isOn = true;
        }
        AudioManagers.Ins.MusicPlayer.mute = isOn;
        AudioManagers.Ins.SoundPlayer.mute = isOn;
    }
    public void vauleChange()
    {
        AudioManagers.Ins.SoundPlayer.volume = audioSlider.value;
        AudioManagers.Ins.MusicPlayer.volume = audioSlider.value;
        audioTxt.text = string.Format("{0:F1} %", audioSlider.value * 100);
    }
    public void re()
    {
        Destroy(gameObject);
        Main.Ins.CreatSelectUI();
    }
}
