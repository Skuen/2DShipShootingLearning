using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormHole : AlphaMonoBehavior
{
    protected string sceneName = "GalaxyDemo";
    protected virtual void OnMouseDown()
    {
        this.LoadGalaxy();
    }

    protected void LoadGalaxy()
    {
        SceneManager.LoadScene(this.sceneName);
    }
}
