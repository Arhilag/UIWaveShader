using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class WaveEffect : MonoBehaviour
{
    public Image targetImage;
    public float waveDuration = 2f;

    private Material material;
    private float currentProgress = 0f;

    void Awake()
    {
        targetImage.material = new Material(targetImage.material);
        material = targetImage.material;
        currentProgress = 0f;
        material.SetFloat("_WaveProgress", currentProgress);
    }


    public void PlayWave()
    {
        currentProgress = 0f;
        material.SetFloat("_WaveProgress", currentProgress);
        StartCoroutine(WaveMove());
    }

    public void StopWave()
    {
        currentProgress = 1f;
        material.SetFloat("_WaveProgress", currentProgress);
    }

    private IEnumerator WaveMove()
    {
        while (currentProgress < 1f)
        {
            currentProgress += Time.unscaledDeltaTime / waveDuration;
            currentProgress = Mathf.Clamp01(currentProgress);
            material.SetFloat("_WaveProgress", currentProgress);
            yield return null;
        }
    }
}
