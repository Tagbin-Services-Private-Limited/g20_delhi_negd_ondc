using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CoreManager : MonoBehaviour
{

    [Header("Panels")]
    [SerializeField] CanvasGroup startPanel;
    [SerializeField] CanvasGroup selectPanel;
    [SerializeField] CanvasGroup videoPanel;

    [Header("Video")]
    [SerializeField] VideoPlayer video;
    [SerializeField] string[] videoNames;
    [SerializeField] bool preparing;

    private void Start()
    {
        video.loopPointReached += VideoEnded;
        video.prepareCompleted += Prepared;
    }

    private void Prepared(VideoPlayer source)
    {
        preparing = false;
    }

    private void VideoEnded(VideoPlayer source)
    {
        Home();
    }

    public void Home()
    {
        video.Stop();

        LeanTween.cancel(videoPanel.gameObject);
        LeanTween.cancel(startPanel.gameObject);
        LeanTween.cancel(selectPanel.gameObject);


        startPanel.gameObject.SetActive(true);
        LeanTween.alphaCanvas(videoPanel, 0, 0.3f).setOnComplete(() => {
            videoPanel.gameObject.SetActive(false);
        });

        LeanTween.alphaCanvas(selectPanel, 0, 0.3f).setOnComplete(() => {
            selectPanel.gameObject.SetActive(false);
        });
        LeanTween.alphaCanvas(startPanel, 1, 0.3f);
    }

    public void Explore()
    {
        LeanTween.cancel(selectPanel.gameObject);
        LeanTween.cancel(startPanel.gameObject);

        selectPanel.gameObject.SetActive(true);
        LeanTween.alphaCanvas(startPanel, 0, 0.3f).setOnComplete(() => {
            startPanel.gameObject.SetActive(false);
        });
        LeanTween.alphaCanvas(selectPanel, 1, 0.3f);
    }

    Coroutine videoOpenRoutine;
    public void OpenVideo(int index)
    {
        ClearOutRenderTexture(video.targetTexture);

        preparing = true;
        video.url =Application.streamingAssetsPath +"/"+ videoNames[index];
        video.Prepare();
        if (videoOpenRoutine != null)
        {
            StopCoroutine(videoOpenRoutine);
        }
        videoOpenRoutine = StartCoroutine(openVideo());
    }

    IEnumerator openVideo()
    {
        pauseIcon.gameObject.SetActive(false);
        LeanTween.cancel(selectPanel.gameObject);

        LeanTween.alphaCanvas(selectPanel, 0, 0.3f).setOnComplete(() => {
            selectPanel.gameObject.SetActive(false);
        });

        while (preparing) yield return null;

        videoPanel.gameObject.SetActive(true);

        LeanTween.alphaCanvas(videoPanel, 1, 0.3f).setOnComplete(() => {
            video.Play();
        });
    }

    [SerializeField] RectTransform pauseIcon;
    public void ToggleVideoPauseResume()
    {      
        if (video.isPlaying)
        {
            video.Pause();
            pauseIcon.gameObject.SetActive(true);
            LeanTween.cancel(pauseIcon);
            LeanTween.alpha(pauseIcon, 1, 0.3f).setFrom(0);
            LeanTween.scale(pauseIcon, Vector3.one, 0.3f).setFrom(Vector3.one * 1.3f);
        }
        else
        {
            video.Play();
            pauseIcon.gameObject.SetActive(false);
        }
    }

    public void ClearOutRenderTexture(RenderTexture renderTexture)
    {
        RenderTexture rt = RenderTexture.active;
        RenderTexture.active = renderTexture;
        GL.Clear(true, true, Color.clear);
        RenderTexture.active = rt;
    }
}

