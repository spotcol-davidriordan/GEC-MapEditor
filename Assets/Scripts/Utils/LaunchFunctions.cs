using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchFunctions : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod]
    public static void Main()
    {
        // lock framerate to screen refresh rate
        Application.targetFrameRate = (int)(Screen.currentResolution.refreshRateRatio.numerator / Screen.currentResolution.refreshRateRatio.denominator);
    }

    
}
