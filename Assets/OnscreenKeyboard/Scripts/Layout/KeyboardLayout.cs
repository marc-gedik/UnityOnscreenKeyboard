using System;
using System.Collections.Generic;

namespace OnScreenKeyboard {
    
    public interface KeyboardKey {


    }

    public class LetterKeyboardKey: KeyboardKey {
        public string Character { get; }
        public string ShiftedCharacter { get; }

        public LetterKeyboardKey(string character, string shiftedCharacter)
        {
            Character = character;
            ShiftedCharacter = shiftedCharacter;
        }
    }   
    
    public class ShiftKeyboardKey: KeyboardKey {}
    public class BackSpaceKeyboardKey: KeyboardKey {}
    
    public class SpaceKeyboardKey: KeyboardKey {}

    public class EnterKeyboardKey: KeyboardKey {}
    
    public class KeyboardRow {
        public KeyboardKey[] Keys { get; }
        public float Offset { get; }

        public KeyboardRow(KeyboardKey[] keys, float offset = 0f) {
            Keys = keys;
            Offset = offset;
        }
    }

    public interface IKeyboardLayout {
        KeyboardRow[] Rows();
        Dictionary<string, (string, string, string, string)> Navigation();
    }
}