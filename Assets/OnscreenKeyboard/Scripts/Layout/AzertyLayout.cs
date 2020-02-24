
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

        public KeyboardRow[] Rows() { return rows; }

        public float Offset() {
            return 0f;
        }
    }

}