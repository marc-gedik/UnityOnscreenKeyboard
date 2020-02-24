
namespace OnScreenKeyboard {
    public enum KeyboardLayout { Azerty }

	public static class KeyboardLayoutList {

		public static IKeyboardLayout GetLayout (KeyboardLayout layout) {
			switch (layout) {
				default:
					return new AzertyLayout();
			}
		}
	}
}