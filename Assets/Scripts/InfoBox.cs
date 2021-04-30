using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoBox : MonoBehaviour
{
    public void ToggleActive(GameObject infoBox) {
        infoBox.SetActive(!infoBox.activeSelf);
    }
}
