namespace OnScreenKeyboard {
	public class EnterKey : Key {

		public override void HandleClick() {
			keyboard.OnSubmit();
		}

	}

}