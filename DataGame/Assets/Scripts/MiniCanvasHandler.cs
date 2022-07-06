using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCanvasHandler : MonoBehaviour
{
private void Start() {
    this.gameObject.SetActive(false);
}

public void showCanvas(bool value)
{
    this.gameObject.SetActive(value);
}
}
