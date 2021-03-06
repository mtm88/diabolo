﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] float maxHealthPoints = 100f;

    private float currentHealthPoints = 100f;

    public float GetHealthAsPercentage
    {
        get
        {
            return currentHealthPoints / maxHealthPoints;
        }
    }
}
