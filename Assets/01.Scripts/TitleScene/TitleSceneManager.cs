using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField]
    private Door _door;
    [SerializeField]
    private CinemachineVirtualCamera _mainCam;
    [SerializeField]
    private TitlePanelUI _titlePanelUI;
    [SerializeField]
    private GoToTutorialPanel _goToTutorialPanel;

    private Sequence _openingSeq;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    private void Update()
    {
        if (_openingSeq != null && _openingSeq.IsActive()) return;
        if (Input.anyKeyDown)
        {
            _titlePanelUI.DisableUI();
            _openingSeq = DOTween.Sequence();
            _door.ModifyOpenStatus(true);
            _openingSeq.AppendInterval(1f);
            _openingSeq.Append(_mainCam.transform.DOMoveZ(7, 1).SetEase(Ease.InExpo));
            _openingSeq.AppendInterval(1f);
            _openingSeq.AppendCallback(() => _goToTutorialPanel.gameObject.SetActive(true));
        }
    }
}
