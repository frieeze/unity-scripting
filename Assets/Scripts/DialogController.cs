using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
   public DialogLine play1 = default;
   public DialogLine play2 = default;
   public DialogLine tr1 = default;
   public DialogLine quit1 = default;
   public DialogLine quit2 = default;

   public TMPro.TextMeshProUGUI dialog = default;
   public DialogsRessourcesController panel = default;
   public DialogsRessourcesController jables = default;
   public DialogsRessourcesController theRock;

   public void play()
   {
      if (!panel.isShowing)
         panel.displayImage(); jables.displayImage();
      if (theRock.isShowing)
      {
         dialog.text = play2.text;
      }
      else
      {
         dialog.text = play1.text;
      }
   }
   public void theRockArrival()
   {
      if (!panel.isShowing)
         panel.displayImage();
      dialog.text = tr1.text;
   }
   public void quit()
   {
      if (!panel.isShowing)
         panel.displayImage(); jables.displayImage();
      if (theRock.isShowing)
      {
         dialog.text = quit2.text;
      }
      else
      {
         dialog.text = quit1.text;
      }
   }

}
