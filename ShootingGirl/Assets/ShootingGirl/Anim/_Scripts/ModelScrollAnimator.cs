using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelScrollAnimator : MonoBehaviour
{
    [SerializeField] private Animator _modelScrollAnimator;

    private AbsCustomScrollSelector<AbsCell> _absCustomScrollSelector;


    private void Awake()
    {
        _absCustomScrollSelector = GameObject.Find("UIController").GetComponent<AbsCustomScrollSelector<AbsCell>>();
    }

    private void Update()
    {
        UpdateScrollModel();
    }

    public void UpdateScrollModel()
    {
        if (_absCustomScrollSelector != null)
         _modelScrollAnimator.Play("ScrollTrigger", 0, _absCustomScrollSelector.scrollbar.value);
    }
}
