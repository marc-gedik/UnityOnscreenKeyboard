
using System.Collections.Generic;

namespace OnScreenKeyboard {

    public class AzertyLayout: IKeyboardLayout {

        private KeyboardRow[] rows = new KeyboardRow[] {
            new KeyboardRow(new KeyboardKey[]{
                new LetterKeyboardKey("a", "A"),
                new LetterKeyboardKey("z", "Z"),
                new LetterKeyboardKey("e", "E"),
                new LetterKeyboardKey("r", "R"),
                new LetterKeyboardKey("t", "T"),
                new LetterKeyboardKey("y", "Y"),
                new LetterKeyboardKey("u", "U"),
                new LetterKeyboardKey("i", "I"),
                new LetterKeyboardKey("o", "O"),
                new LetterKeyboardKey("p", "P")
            }),
            new KeyboardRow(new KeyboardKey[]{
                new LetterKeyboardKey("q", "Q"),
                new LetterKeyboardKey("s", "S"),
                new LetterKeyboardKey("d", "D"),
                new LetterKeyboardKey("f", "F"),
                new LetterKeyboardKey("g", "G"),
                new LetterKeyboardKey("h", "H"),
                new LetterKeyboardKey("j", "J"),
                new LetterKeyboardKey("k", "K"),
                new LetterKeyboardKey("l", "L"),
                new LetterKeyboardKey("m", "M")
            }),
                new KeyboardRow(new KeyboardKey[]{
                new ShiftKeyboardKey(),
                new LetterKeyboardKey("w", "W"),
                new LetterKeyboardKey("x", "X"),
                new LetterKeyboardKey("c", "C"),
                new LetterKeyboardKey("v", "V"),
                new LetterKeyboardKey("b", "B"),
                new LetterKeyboardKey("n", "N"),
                new LetterKeyboardKey("'", "?"),
                new BackSpaceKeyboardKey()
            }),
                new KeyboardRow(new KeyboardKey[]{
                new LetterKeyboardKey(",", ";"),
                new SpaceKeyboardKey(),
                new LetterKeyboardKey(".", "."),
                new EnterKeyboardKey()
            })
        };

        private Dictionary<string, (string, string, string, string)> navigation = new Dictionary<string, (string, string, string, string)>() {
            {"a", (null,"q",null,"z")},
            {"z", (null,"s","a","e")},
            {"e", (null,"d","z","r")},
            {"r", (null,"f","e","t")},
            {"t", (null,"g","r","y")},
            {"y", (null,"h","t","u")},
            {"u", (null,"j","y","i")},
            {"i", (null,"k","u","o")},
            {"o", (null,"l","i","p")},
            {"p", (null,"m","o",null)},
            {"q", ("a","Shift",null,"s")},
            {"s", ("z","Shift","q","d")},
            {"d", ("e","w","s","f")},
            {"f", ("r","x","d","g")},
            {"g", ("t","c","f","h")},
            {"h", ("y","b","g","j")},
            {"j", ("u","n","h","k")},
            {"k", ("i","'","j","l")},
            {"l", ("o","BackSpace","k","m")},
            {"m", ("p","BackSpace","l",null)},
            {"w", ("d","Space","Shift","x")},
            {"x", ("f","Space","w","c")},
            {"c", ("g","Space","x","v")},
            {"v", ("g","Space","c","b")},
            {"b", ("h","Space","v","n")},
            {"n", ("j","Space","b","'")},
            {"'", ("k",".","n","BackSpace")},
            {",", ("Shift",null,null,"Space")},
            {".", ("'",null,"Space","Enter")},
            {"Shift", ("q", ",", null, "w")},
            {"BackSpace", ("l", "Enter", "'", null)},
            {"Enter", ("BackSpace", null, ".", null)},
            {"Space", ("w", null, ",", ".")}
        };

        public KeyboardRow[] Rows() { return rows; }

        public Dictionary<string, (string, string, string, string)> Navigation() {
            return navigation;
        }
    }

}