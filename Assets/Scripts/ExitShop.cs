using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ExitShop : MonoBehaviour
{
    [SerializeField] private Button _exitShop;
   

    public event UnityAction ActivatedShop;

    private void OnEnable()
    {
        _exitShop.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        _exitShop.onClick.RemoveListener(Exit);
    }



    private void Exit()
    {
        gameObject.SetActive(false);
    }
}
