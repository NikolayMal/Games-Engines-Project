using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Visualizer : MonoBehaviour
{
    public GameObject parent;
    private int SizeX = callGrid.x;

    public AudioClip music;
    public bool loop = true;
    AudioSource musicSource;

    private float imageHeight = 10f;
    private float imageMinHeight = 1.5f;
    public int visualizerSimples = 64;


    //
    private Color visualizerColor = new Color(220, 0, 240);
    private Color color1 = Color.gray;

    // Stores Child Objects
    VisualizerObject[] visualizerObjects;


    // Start is called before the first frame update
    void Start()
    {
        int gap = 10;
        for (int col = 0; col < SizeX + gap; col++)
        {
            // Create Image which displays Visualizer
            GameObject image = new GameObject();
            Image Newimage = image.AddComponent<Image>();
            //Newimage.transform.parent = this.transform;
            Newimage.GetComponentInParent<RectTransform>().SetParent(parent.transform);
            Newimage.rectTransform.sizeDelta = new Vector2(1, 1);
            Newimage.rectTransform.Translate(new Vector3(col - (gap / 2), 3f, -5));
            Newimage.name = "Visualizer Image : " + col;
            image.AddComponent<VisualizerObject>();
            image.GetComponent<Image>().color = color1;
        }

        visualizerObjects = GetComponentsInChildren<VisualizerObject>();

        // Music
        musicSource = new GameObject("musicSource").AddComponent<AudioSource>();
        musicSource.loop = loop;
        musicSource.clip = music;
        musicSource.volume = 0.5f;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Get Spectrum Data
        float[] spectrumData = new float[256];
        AudioListener.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

        for (int i = 0; i < visualizerObjects.Length; i++)
        {
            // Set New Size
            Vector2 newImageSize = visualizerObjects[i].GetComponent<RectTransform>().rect.size;
            // Mathf.Lert smooths the size changing
            newImageSize.y = Mathf.Lerp(newImageSize.y, imageMinHeight + (spectrumData[i] * (imageHeight - imageMinHeight) * 5.0f), 0.25f);
            // Change Size on object
            visualizerObjects[i].GetComponentInParent<RectTransform>().sizeDelta = newImageSize;
        }
    }
}
