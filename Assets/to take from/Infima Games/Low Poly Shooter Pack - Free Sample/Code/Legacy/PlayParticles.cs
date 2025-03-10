using System.Collections;
using UnityEngine;

namespace to_take_from.Infima_Games.Low_Poly_Shooter_Pack___Free_Sample.Code.Legacy
{
    public class PlayParticles : MonoBehaviour
    {
        [Header("Delay Settings")]
        public float initialDelay = 1.0f;
        public float waitBetweenPlaying = 5.0f;

        [Header("Particle Settings")]
        public ParticleSystem particles;

        [Range(0.0f, 1.0f)]
        public float particleScale = 1.0f;

        private void Start()
        {
            StartCoroutine(WaitBeforePlaying());
            //Set particle local scale
            particles.transform.localScale = new Vector3(particleScale, particleScale, particleScale);
        }

        private IEnumerator WaitBeforePlaying()
        {
            //Wait for set amount of time
            yield return new WaitForSeconds(initialDelay);
            StartCoroutine(PlayEffect());
        }
        private IEnumerator PlayEffect()
        {
            //Wait for set amount of time
            yield return new WaitForSeconds(waitBetweenPlaying);
            //Play effects here
            particles.Play();
            //Restart the coroutine
            StartCoroutine(PlayEffect());
        }
    }
}