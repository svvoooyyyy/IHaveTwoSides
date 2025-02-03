using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageGallery : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite[] _sprites;
    private int index = 0;
    [SerializeField] private bool _changeImageFromStart = true;

    private void Start()
    {
        if (_changeImageFromStart) { ChangeImage(); }
    }


    public void ChangeImage() {
        
        _image.sprite = _sprites[index];
        if (index < _sprites.Length-1) { index += 1; }
    }
}
