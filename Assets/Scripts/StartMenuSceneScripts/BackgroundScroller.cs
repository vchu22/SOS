using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class BackgroundScroller : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private RectTransform _parentRectTransform;
    [SerializeField] private RawImage _image;
    [Header("Settings")]
    [SerializeField] private Vector2 repeatCount;
    [SerializeField] private Vector2 scroll;
    [SerializeField] private Vector2 offset;

    private void Awake()
    {
        if (!_image) _image = GetComponent<RawImage>();

        _image.uvRect = new Rect(offset, repeatCount);
    }

    // Start is called before the first frame update
    private void Start()
    {
        if (!_rectTransform) _rectTransform = GetComponent<RectTransform>();
        if (!_parentRectTransform) _parentRectTransform = GetComponentInParent<RectTransform>();

        SetScale();
    }

    // Update is called once per frame
    private void Update()
    {
#if UNITY_EDITOR
        // Only done in the Unity editor since later it is unlikely that your screensize changes
        SetScale();
#endif
        offset += scroll * Time.deltaTime;
        _image.uvRect = new Rect(offset, repeatCount);
    }

    private void SetScale()
    {
        // get the diagonal size of the screen since the parent is the Canvas with
        // ScreenSpace overlay it is always fiting the screensize
        var parentCorners = new Vector3[4];
        _parentRectTransform.GetLocalCorners(parentCorners);
        var diagonal = Vector3.Distance(parentCorners[0], parentCorners[2]);

        // set width and height to at least the diagonal
        _rectTransform.sizeDelta = new Vector2(diagonal, diagonal);
    }
}
