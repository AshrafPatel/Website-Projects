"use strict";

Object.defineProperty(exports, "__esModule", {
	value: true
});
exports.default = onRecaptchaChange;
function onRecaptchaChange(recaptchaValue) {
	console.log("Invisible reCAPTCHA value set");
	this.setState({ recaptchaValue: recaptchaValue });
	if (this.props.recaptcha && this.props.recaptcha.size === "invisible") {
		this.process();
	}
}