﻿using UnityEngine;

namespace Assets.Game.Scripts
{
    public class DiscCollection : MonoBehaviour
    {
        private bool animating = false;

        private float lerpLength = 2f;
        private Vector3 startScale;

        private float startTime;

        // Use this for initialization
        void Start()
        {
            this.startScale = this.transform.localScale;
        }

        void Update()
        {
            if (this.animating)
            {
                this.transform.localScale = Vector3.Lerp(
                    this.startScale,
                    this.startScale * 2,
                    (Time.time - this.startTime) / this.lerpLength);

                if (Time.time >= this.startTime + this.lerpLength)
                {
                    Destroy(this.gameObject, 1);
                }
            }
        }

        void OnMouseDown()
        {
            if (!this.animating)
            {
                this.startTime = Time.time;
                this.animating = true;
            }
        }
    }
}
