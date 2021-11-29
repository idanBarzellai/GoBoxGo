using UnityEngine;
using UnityEngine.UI;

public class VibrationBool : MonoBehaviour
{
    private Toggle vibrate;
    public bool isVibrating = true;

    private void Start()
    {
        vibrate = GameObject.FindGameObjectWithTag("Vibration").GetComponent<Toggle>();
    }
    public void setVibrateByToggle(bool setVibrate)
    {
        isVibrating = setVibrate;
    }

}
