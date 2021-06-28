using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class break_block : MonoBehaviour
{
   
    private ParticleSystem particle;
    private SpriteRenderer sr;
    private BoxCollider2D bc;

    private void Awake(){
        particle = GetComponentInChildren <ParticleSystem>();
        sr = GetComponentInChildren<SpriteRenderer>();
        bc = GetComponentInChildren<BoxCollider2D>();
    }

 
    private IEnumerator Break(){
        particle.Play();

        sr.enabled = false;
        bc.enabled = false;

        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }

    private void OnMouseDown(){
        StartCoroutine(Break());
    }

}
