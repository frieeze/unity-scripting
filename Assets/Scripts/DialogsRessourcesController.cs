using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogsRessourcesController : MonoBehaviour
{
   private GameObject image;
   public bool isShowing { get; private set; } = false;

   private void Awake()
   {
      image = gameObject;
      image.SetActive(false);
   }
   public void displayImage()
   {
      isShowing = true;
      image.SetActive(true);
   }
}
