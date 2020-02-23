namespace OnScreenKeyboard {
	public class BackSpaceKey : Key {

		public override void HandleClick() {
			keyboard.OnDelete();
		}

	}

}