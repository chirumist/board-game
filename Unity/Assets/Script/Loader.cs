using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene {
        GameScene,
    }
    public static void load(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }
}
