using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Lucas
{

   [CustomEditor(typeof(GameSettings))]
   public class GameSettingsEditor : Editor
   {
      private GameSettings gameSettingsScript;

      private void OnEnable()
      {
         EditorApplication.playModeStateChanged += PlayModeChanged;
         gameSettingsScript = (GameSettings) target;
      }

      /// <summary>
      /// Runs when editor state is changed to play mode
      /// </summary>
      /// <param name="state"></param>
      private void PlayModeChanged(PlayModeStateChange state)
      {
         if(state == PlayModeStateChange.EnteredPlayMode)
         {
            if(gameSettingsScript.musicAudioMixer == null)
            {
               Debug.LogError("Hey idiot you haven't set the music audio mixer");
               EditorApplication.isPlaying = false;
               return;
            }

            if(gameSettingsScript.volumeAudioMixer == null)
            {
               Debug.LogError("Hey idiot you haven't set the volume audio mixer");
               EditorApplication.isPlaying = false;
               return;
            }
         }
      }
   }
}

