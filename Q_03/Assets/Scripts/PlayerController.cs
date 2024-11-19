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
        //����4 (����)
        if (_audio.isPlaying)
            return;
        DeadEvent?.Invoke();
        DeadEvent = null;
        transform.GetChild(0).gameObject.SetActive(false);
        _audio.Play();
        StartCoroutine(DieCo());

    }

    //����4 (�߰�)
    IEnumerator DieCo() {

        yield return new WaitForSeconds(_audio.clip.length);
        transform.GetChild(0).gameObject.SetActive(true);
        gameObject.SetActive(false);

    }

    //����5 (�߰�)
    public event Action DeadEvent;

}
