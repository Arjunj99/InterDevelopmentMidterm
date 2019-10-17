using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardZone {
    public enum hazardType { whirlpool, storm, shark };
    private hazardType type;
    private Vector3 position;
    private Vector3 scale;

    public HazardZone(hazardType type, Vector3 position, Vector3 scale) {
        this.type = type;
        this.position = position;
        this.scale = scale;
    }
}
