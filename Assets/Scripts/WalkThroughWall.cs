using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkThroughWall : MonoBehaviour {

    private Color NSColor = new Color(0, 0, 1, 0.3f);
    private Color defaultColor = new Color(1, 1, 1, 1);

    //private void OnEnable()
    //{
    //    gameObject.layer = LayerMask.NameToLayer("Not Solid");
    //}

    //private void OnDisable()
    //{
    //    gameObject.layer = LayerMask.NameToLayer("Default");
    //}

    public void SetLayerToNotSolid()
    {
        gameObject.layer = LayerMask.NameToLayer("Not Solid");
        GetComponent<Renderer>().material.color = NSColor;
    }


    public void SetLayerToDefault()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        GetComponent<Renderer>().material.SetColor("_Color",defaultColor);
    }
}
