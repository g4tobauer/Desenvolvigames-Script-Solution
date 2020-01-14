﻿using Assets.Scenes.Miscelanious;
using Assets.Scenes.Scripts.Miscelanious.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scenes.Scripts.Objects
{
    public class PickupableObject : MonoBehaviour, IPickupable
    {
        public SpriteRenderer m_SpriteRenderer;

        public virtual void Start()
        {
            CanBePicked = true;
        }

        #region IPickupable
        public bool CanBePicked { get; private set; }
        public Constants.Pickupable.PickupableType PickupableType { get; protected set; }
        public T Pickup<T>() where T : IPickupable
        {
            CanBePicked = false;
            return (T)Convert.ChangeType(this, typeof(T));
        }
        #endregion
    }
}
