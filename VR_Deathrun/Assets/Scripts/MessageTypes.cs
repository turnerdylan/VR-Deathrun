using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GenericPacket {
    public string type;
    public string data;

    public GenericPacket(string t, string d) {
        type = t;
        data = d;
    }
}

[System.Serializable]
public class PlayerTransform {
    public Vector3 position;

    public PlayerTransform(Vector3 p) {
        position = p;
    }
}
