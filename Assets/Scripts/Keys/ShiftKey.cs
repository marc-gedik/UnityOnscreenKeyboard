namespace OnScreenKeyboard {
    public class ShiftKey : Key {

		private bool shifted = false;

		public override void HandleClick() {
            shifted = !shifted;
			keyboard.OnShift(shifted);
		}

	}
}
