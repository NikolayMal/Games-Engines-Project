using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Visualizer : MonoBehaviour
{
    public GameObject parent;
    private int SizeX = callGrid.x;
    private Color red = Color.red;

    public AudioClip music;
    public bool loop = true;
    AudioSource musicSource;

    private float imageHeight = 10f;
    private float imageMinHeight = 1.5f;
    public int visualizerSimples = 64;


    //
    private Color visualizerColor = Color.red;
    VisualizerObject[] visualizerObjects;

    // Start is called before the first frame update
    void Start()
    {
        int gap = 10;
        for (int i = 0; i < 4; i++)
        {
            for (int col = 0; col < SizeX + gap; col++)
            {
                // GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                // cube.transform.position = transform.TransformPoint(new Vector3(col - (gap / 2) - 1, 4.5f, 0));
                // cube.transform.rotation = transform.rotation;
                // cube.GetComponent<Renderer>().material.color = Color.red;
                // cube.transform.parent = this.transform;
                // cube.layer = 1;

                GameObject image = new GameObject();
                Image Newimage = image.AddComponent<Image>();
                //Newimage.transform.parent = this.transform;
                Newimage.GetComponentInParent<RectTransform>().SetParent(parent.transform);
                Newimage.rectTransform.sizeDelta = new Vector2(1, 1);
                Newimage.rectTransform.Translate(new Vector3(col - (gap / 2) - 1, 3f, 0));
                Newimage.name = "Visualizer Image : " + col;
                image.AddComponent<VisualizerObject>();
            }
        }
        visualizerObjects = GetComponentsInChildren<VisualizerObject>();

        //
        musicSource = new GameObject("musicSource").AddComponent<AudioSource>();
        musicSource.loop = loop;
        musicSource.clip = music;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        float[] spectrumData = musicSource.GetSpectrumData(visualizerSimples, 0, FFTWindow.Triangle);
        for (int i = 0; i < visualizerObjects.Length; i++)
        {
            visualizerObjects[i].GetComponent<Image>().color = visualizerColor;

            // Set New Size
            Vector2 newImageSize = visualizerObjects[i].GetComponent<RectTransform>().rect.size;
            // Mathf.Lert smooths the size changing
            newImageSize.y = Mathf.Lerp(newImageSize.y, imageMinHeight + (spectrumData[i] * (imageHeight - imageMinHeight) * 5.0f), 0.25f);
            // Change Size on object
            visualizerObjects[i].GetComponentInParent<RectTransform>().sizeDelta = newImageSize;
        }
    }
}
