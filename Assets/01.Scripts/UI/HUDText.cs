using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDText : PoolableMono
{
    private TextMeshPro txt;
    private Animator anim;
    private void Awake()
    {
        txt = GetComponent<TextMeshPro>();
        anim = GetComponent<Animator>();
    }

    public void ShowText(int value,Vector3 pos)
    {
        transform.position = pos;
        txt.text = value.ToString();
        anim.SetTrigger("Show");
        Invoke("SetActive", Random.Range(.8f,1.2f));
    }
    private void SetActive()
    {
        PoolManager.Instance.Push(this);
    }
    public override void Init()
    {
        anim.ResetTrigger("Show");
    }
}
