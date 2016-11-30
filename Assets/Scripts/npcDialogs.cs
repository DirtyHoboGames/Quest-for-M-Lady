using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Assets.Scripts {
    public class npcDialogs {

            static Dictionary<string, string> dialogs = new Dictionary<String, string>();

        // Use this for initialization
        void Start() {

            dialogs.Add("MrRuntu", "Get rekt m8 *hits you*");
            dialogs.Add("Mikko", "Oh shit waddup");

        }

        // Update is called once per frame
        void Update() {

        }

        public static string getDialog(string npcName) {

            string dialog = "";

            if (dialogs.ContainsKey(npcName)) {

                dialog = dialogs[npcName] + " regards " + npcName;
            }
            else {

                dialog = "eipä ollu";
            }
            return dialog;
        }
    }
}
