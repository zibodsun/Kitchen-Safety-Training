using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransManager : MonoBehaviour
{
    public AnimationClip fadeAnimation;
    public Animator anim;
    public bool debugLoadScene;

    [Header("Objects to disable in introduction")]
    public GameObject environment;
    public GameObject ui;
    public GameObject objects;

    float _fadeTime;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _fadeTime = fadeAnimation.length;
    }

    private void Update()
    {
        if (debugLoadScene) { 
            LoadNextScene(); 
            debugLoadScene = false;
        }
    }

    public void LoadNextScene() {
        anim.Play("FadeOut");
        StartCoroutine(LoadSceneDelayed(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadSceneDelayed(int buildIndex) {
        yield return new WaitForSeconds(_fadeTime);
        SceneManager.LoadScene(buildIndex);
        anim.Play("FadeIn");
    }

    public void OnboardingToIntroductionSwap() {
        environment.SetActive(false);
        ui.SetActive(false);
        objects.SetActive(false);
    }
}
