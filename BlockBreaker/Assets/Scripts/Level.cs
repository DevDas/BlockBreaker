﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] public int BreakableBlocks;
    
    public void CountBreakableBlocks()
    {
        BreakableBlocks++;
    }
}