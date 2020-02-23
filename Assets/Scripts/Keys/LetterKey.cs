using TMPro;

namespace OnScreenKeyboard {

	public class LetterKey : Key {

        public LetterKeyboardKey key;

		private bool _shifted = false;

		public bool shifted {
			get { return _shifted; }
			set {
				_shifted = value;
				label.text = _shifted ? key.ShiftedCharacter : key.Character;
			}
		}

		public void Shift(bool value) {
			shifted = value;
		}

		public string GetCharacter () {
			return _shifted ? key.ShiftedCharacter : key.Character;
		}

		public override void HandleClick() {
			keyboard.OnKeyPressed(GetCharacter());
		}

	}
	

}