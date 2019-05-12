'use strict';

Object.defineProperty(exports, "__esModule", {
	value: true
});

var _extends2 = require('babel-runtime/helpers/extends');

var _extends3 = _interopRequireDefault(_extends2);

var _getPrototypeOf = require('babel-runtime/core-js/object/get-prototype-of');

var _getPrototypeOf2 = _interopRequireDefault(_getPrototypeOf);

var _classCallCheck2 = require('babel-runtime/helpers/classCallCheck');

var _classCallCheck3 = _interopRequireDefault(_classCallCheck2);

var _createClass2 = require('babel-runtime/helpers/createClass');

var _createClass3 = _interopRequireDefault(_createClass2);

var _possibleConstructorReturn2 = require('babel-runtime/helpers/possibleConstructorReturn');

var _possibleConstructorReturn3 = _interopRequireDefault(_possibleConstructorReturn2);

var _inherits2 = require('babel-runtime/helpers/inherits');

var _inherits3 = _interopRequireDefault(_inherits2);

var _react = require('react');

var _react2 = _interopRequireDefault(_react);

var _reactGoogleRecaptcha = require('react-google-recaptcha');

var _reactGoogleRecaptcha2 = _interopRequireDefault(_reactGoogleRecaptcha);

var _onSubmit = require('./on-submit');

var _onSubmit2 = _interopRequireDefault(_onSubmit);

var _onSuccess = require('./on-success');

var _onSuccess2 = _interopRequireDefault(_onSuccess);

var _onRecaptchaChange = require('./on-recaptcha-change');

var _onRecaptchaChange2 = _interopRequireDefault(_onRecaptchaChange);

var _defaultProps = require('./default-props');

var _defaultProps2 = _interopRequireDefault(_defaultProps);

var _awaitRecaptchaValue = require('./await-recaptcha-value');

var _awaitRecaptchaValue2 = _interopRequireDefault(_awaitRecaptchaValue);

var _process = require('./process');

var _process2 = _interopRequireDefault(_process);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var NetlifyForm = function (_React$Component) {
	(0, _inherits3.default)(NetlifyForm, _React$Component);

	function NetlifyForm(props) {
		(0, _classCallCheck3.default)(this, NetlifyForm);

		var _this = (0, _possibleConstructorReturn3.default)(this, (NetlifyForm.__proto__ || (0, _getPrototypeOf2.default)(NetlifyForm)).call(this, props));

		_this.state = {
			error: false,
			loading: false,
			success: false
		};
		_this.onSubmit = _onSubmit2.default.bind(_this);
		_this.onSuccess = _onSuccess2.default.bind(_this);
		_this.onRecaptchaChange = _onRecaptchaChange2.default.bind(_this);
		_this.awaitRecaptchaValue = _awaitRecaptchaValue2.default.bind(_this);
		_this.process = _process2.default.bind(_this);
		return _this;
	}

	(0, _createClass3.default)(NetlifyForm, [{
		key: 'render',
		value: function render() {
			var _this2 = this;

			var _props = this.props,
			    name = _props.name,
			    action = _props.action,
			    honeypotName = _props.honeypotName,
			    recaptcha = _props.recaptcha;

			var dataAttrs = {
				'data-netlify': 'true'
			};
			if (honeypotName) {
				dataAttrs['data-netlify-honeypot'] = honeypotName;
			}
			if (recaptcha) {
				dataAttrs['data-netlify-recaptcha'] = 'true';
			}
			return _react2.default.createElement(
				'form',
				(0, _extends3.default)({
					ref: function ref(el) {
						return _this2.form = el;
					},
					onSubmit: this.onSubmit,
					name: name,
					action: action
				}, dataAttrs),
				_react2.default.createElement('input', {
					type: 'hidden',
					name: 'form-name',
					value: name
				}),
				_react2.default.createElement('input', {
					ref: function ref(el) {
						return _this2.honeypot = el;
					},
					type: 'text',
					name: honeypotName,
					style: { display: 'none' }
				}),
				this.props.children((0, _extends3.default)({}, this.state, {
					recaptcha: _react2.default.createElement(_reactGoogleRecaptcha2.default, (0, _extends3.default)({}, recaptcha, {
						ref: function ref(el) {
							return _this2.recaptchaEl = el;
						},
						onChange: this.onRecaptchaChange
					}))
				}))
			);
		}
	}]);
	return NetlifyForm;
}(_react2.default.Component);

NetlifyForm.defaultProps = _defaultProps2.default;

exports.default = NetlifyForm;