using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadingUI : MonoBehaviour
{
    public Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (null != _slider)
        {
            _slider.value += 0.1f;
            if (0.99 <= _slider.value)
            {
                Main.Ins.CreatSelectUI();
            }
        }
    }
}
