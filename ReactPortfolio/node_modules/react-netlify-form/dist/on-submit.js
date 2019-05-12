"use strict";

Object.defineProperty(exports, "__esModule", {
	value: true
});

var _regenerator = require("babel-runtime/regenerator");

var _regenerator2 = _interopRequireDefault(_regenerator);

var _asyncToGenerator2 = require("babel-runtime/helpers/asyncToGenerator");

var _asyncToGenerator3 = _interopRequireDefault(_asyncToGenerator2);

var onSubmit = function () {
	var _ref = (0, _asyncToGenerator3.default)( /*#__PURE__*/_regenerator2.default.mark(function _callee(e) {
		var res;
		return _regenerator2.default.wrap(function _callee$(_context) {
			while (1) {
				switch (_context.prev = _context.next) {
					case 0:
						console.log("Netlify form submit...");
						e.preventDefault();

						// If submition is disabled

						if (this.props.canSubmit) {
							_context.next = 4;
							break;
						}

						return _context.abrupt("return");

					case 4:
						if (!this.honeypot.value) {
							_context.next = 7;
							break;
						}

						console.error("Honeypot value is set. Cannot submit form.");
						return _context.abrupt("return");

					case 7:
						if (!(this.props.recaptcha && this.props.recaptcha.size === "invisible")) {
							_context.next = 23;
							break;
						}

						if (!(this.props.recaptcha.size === "invisible")) {
							_context.next = 23;
							break;
						}

						console.log("Executing invisible reCAPTCHA...");
						_context.prev = 10;
						_context.next = 13;
						return this.recaptchaEl.execute();

					case 13:
						res = _context.sent;

						console.log("reCAPTCHA response: " + res);
						return _context.abrupt("return");

					case 18:
						_context.prev = 18;
						_context.t0 = _context["catch"](10);

						console.log("reCAPTCHA execution error");
						console.error(_context.t0);
						return _context.abrupt("return", this.setState({
							loading: false,
							error: false,
							success: false,
							recaptchaError: true
						}));

					case 23:
						_context.next = 25;
						return this.process();

					case 25:
					case "end":
						return _context.stop();
				}
			}
		}, _callee, this, [[10, 18]]);
	}));

	return function onSubmit(_x) {
		return _ref.apply(this, arguments);
	};
}();

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

exports.default = onSubmit;