﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlatController : MonoBehaviour {
    public Color lightsOnColor;
    public Image back;

    public BuildingController building;

    public void TurnLightsOn()
    {
        back.color = lightsOnColor;
    }
}
