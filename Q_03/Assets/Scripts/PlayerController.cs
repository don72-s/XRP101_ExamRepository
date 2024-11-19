using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    [field: Range(0, 100)]
    public int Hp { get; private set; }

    private AudioSource _audio;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _audio = GetComponent<AudioSource>();
    }
    
    public void TakeHit(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //수정4 (수정)
        if (_audio.isPlaying)
            return;
        DeadEvent?.Invoke();
        DeadEvent = null;
        transform.GetChild(0).gameObject.SetActive(false);
        _audio.Play();
        StartCoroutine(DieCo());

    }

    //수정4 (추가)
    IEnumerator DieCo() {

        yield return new WaitForSeconds(_audio.clip.length);
        transform.GetChild(0).gameObject.SetActive(true);
        gameObject.SetActive(false);

    }

    //수정5 (추가)
    public event Action DeadEvent;

}
