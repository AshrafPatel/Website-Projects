"use strict";

Object.defineProperty(exports, "__esModule", {
	value: true
});

var _promise = require("babel-runtime/core-js/promise");

var _promise2 = _interopRequireDefault(_promise);

exports.default = awaitRecaptchaValue;

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function awaitRecaptchaValue() {
	var _this = this;

	return new _promise2.default(function (resolve) {
		var interval = setInterval(function () {
			if (_this.state.recaptchaValue) {
				clearInterval(interval);
				resolve();
			}
		}, 1);
	});
}