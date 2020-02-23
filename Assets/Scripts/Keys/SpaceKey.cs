namespace OnScreenKeyboard {
    public class SpaceKey : Key {

		public override void HandleClick() {
			keyboard.OnKeyPressed(" ");
		}

	}
}
