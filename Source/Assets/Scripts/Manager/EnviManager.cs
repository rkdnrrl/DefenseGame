using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviManager : MonoBehaviour
{
    public Material dayMaterial;
    public Material nightMaterial;

    public GameObject dayLight;
    public GameObject nightLight;

    private void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 0.5f);
    }

    public void Btn_Day()
    {
        RenderSettings.skybox = dayMaterial;
        dayLight.SetActive(true);
        nightLight.SetActive(false);
    }

    public void Btn_Night()
    {
        RenderSettings.skybox = nightMaterial;
        dayLight.SetActive(false);
        nightLight.SetActive(true);
    }
}
